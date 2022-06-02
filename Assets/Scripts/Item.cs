using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string description;
    public List<string> recipes;

    private Vector3 mousePosition;
    private Camera cam;
    /*
     * 0 = follow mouse
     * 1 = snap to slot
     * 2 = delete self
     */
    private int state;
    private Vector3 hoverScale, originalScale;

    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        originalScale = transform.localScale;
        hoverScale = originalScale + new Vector3(0.25f, 0.25f, 0.0f);
        cam = Camera.main;
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0.0f;
        transform.position = mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        // keep track of where mouse is
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0.0f;
        //Debug.Log(mousePosition);

        //Debug.Log(state);

        /* FSM */
        // if nothing happening to item, follow mouse
        if (state == 0)
        {
            transform.position = mousePosition;
            
        }
        // if let go, snap to any colliding slots
        else if (state == 1)
        {
            Debug.Log("implement slot snapping");
        }
        // if let go and not slots collided, delete self
        else if (state == 2)
        {
            //Debug.Log("implement delete self");
            Destroy(gameObject, 0.5f);
        }
    }



    // does actions when mouse is hovering over object
    void OnMouseOver()
    {
        // pop out item
        transform.localScale = hoverScale;
        // allow item to be dragged
        if (Input.GetMouseButton(0)) // check left button
        {
            state = 0;
        }
        else
        {
            // only delete self if not being dragged and not in slot
            if (state != 1)
            {
                state = 2;
            }
        }
    }

    // does actions when mouse leaves something
    void OnMouseExit()
    {
        // would like item to go back to regular size
        transform.localScale = originalScale;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // if slot, snap to it
        if (col.gameObject.tag == "Slot")
        { 
            state = 1;
            transform.position = col.gameObject.transform.position;
            
        }
    }
}
