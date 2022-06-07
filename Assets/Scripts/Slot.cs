using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    /*
     * FIXME: later, add a UI object that displays quantity 
     * on top of slot and item in slot.
    */
    public GameObject item;
    public int itemQuantity;

    private float deleteTime;

    // Start is called before the first frame update
    void Start()
    {
        item = null;
        itemQuantity = 0;
        deleteTime = 0.0f;
    }


    // check whether the slot is empty or not
    public bool checkIsEmpty()
    {
        if ((item == null) && (itemQuantity == 0))
            return true;
        else
            return false;
    }

    // calculate time elasped
    public bool timeElapsed(float minimumWait)
    {
        if ((Time.time - deleteTime) >= minimumWait)
            return true;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        // check status
        if (item == null)
        {
            itemQuantity = 0;
        }
        if (itemQuantity <= 0)
        {
            Destroy(item, 0.01f);
        }
    }

    // does action when mouse hovers over object
    void OnMouseOver()
    {
        // allow deleting every 0.5s
        if (!checkIsEmpty() && timeElapsed(0.5f) && (Input.GetMouseButton(1)))
        {
            Debug.Log("waited");
            itemQuantity--;
            // update delete time
            deleteTime = Time.time;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // if collision object is an item
        if (col.gameObject.GetComponent<Item>())
        {
            // if slot is empty
            if (item == null)
            {
                item = col.gameObject;
                itemQuantity = 1;
                // col.gameObject.state = 1;
            }
            // if adding same kind of item into slot
            else if (col.gameObject.tag == item.tag)
            {
                itemQuantity++;
                // let extra item delete itself
                Destroy(col.gameObject, 0.5f);
            }
            // do nothing in all other cases (let item destroy itself)
        }
    }
}
