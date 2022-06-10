using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    // six slots in a pot
    public GameObject[] slots = new GameObject[6];
    private string recipeCode;
    // dictionary of all recipes
    private Dictionary<string, GameObject> Recipes = new Dictionary<string, GameObject>();
    // tag to symol conversion
    private Dictionary<string, string> tagConversion = new Dictionary<string, string>();

    // Start is called before the first frame update
    void Start()
    {
        recipeCode = "";
        // add to tag conversion
        tagConversion.Add("Hydrogen", "H");
        tagConversion.Add("Oxygen", "O");
    }

    // Update is called once per frame
    void Update()
    {
        // reset recipe code
        recipeCode = "";
        // get information from slots 1-5
        int i;
        for (i = 0; i < 5; i++)
        {
            // get slot script
            Slot slotScript = slots[i].gameObject.GetComponent<Slot>();
            // access values
            if (slotScript.checkIsEmpty() == false)
            {
                string itemTag = slotScript.getItemName();
                string itemCode = "";
                // add to recipe code
                if (tagConversion.TryGetValue(itemTag, out itemCode))
                {
                    recipeCode += itemCode;
                    recipeCode += slotScript.getItemQuantity().ToString();
                }
            }
        }
        

        Debug.Log(recipeCode);
    }
}
