using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public string description;
    public List<string> recipes;
    public GameObject item;

    private Vector3 hoverScale, originalScale;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        hoverScale = originalScale + new Vector3(0.5f, 0.5f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // does actions when mouse is hovering over object
    void OnMouseOver()
    {
        // enlarge generator
        transform.localScale = hoverScale;
    }

    // does actions when mouse leaves something
    void OnMouseExit()
    {
        // would like geenerator to go back to regular size
        transform.localScale = originalScale;
    }

    // does actions when mouse button is pressed
    void OnMouseDown()
    {
        if (item == null)
        {
            Debug.Log("no item selected to generate.");
        }
        else
        {
            // generate item
            GameObject obj = GameObject.Instantiate(item,
                    transform.position,
                    Quaternion.identity);
        }
    }
}
