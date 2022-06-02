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

    // Start is called before the first frame update
    void Start()
    {
        item = null;
        itemQuantity = 0;
    }


    // check whether the slot is empty or not
    public static bool checkIsEmpty()
    {
        /*
        if ((item == null) && (itemQuantity == 0))
            return true;
        else
            return false;
        */
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if (item == null)
        {
            itemQuantity = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Item")
        {
            // if slot is empty
            if (item == null)
            {
                item = col.gameObject;
                itemQuantity = 1;
                // state = 1;
            }
            // if adding same kind of item into slot
            else if (col.gameObject == item)
            {
                itemQuantity++;
            }
            // do nothing in all other cases (let item destroy itself)
        }
    }
}
