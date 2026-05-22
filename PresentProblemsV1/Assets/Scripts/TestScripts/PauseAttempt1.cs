using UnityEngine;

public class PauseAttempt1 : MonoBehaviour
{
    public bool inventoryOut;
    public GameObject InventoryOBJ;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryOut = false;


    }


    // Update is called once per frame
    void Update()
    {
        


    }

    public void inventoryButton()
    {
        if (inventoryOut)
        {
            InventoryOBJ.SetActive(false);
            inventoryOut = false;
        }
        else
        {
            inventoryOut = true;
            InventoryOBJ.SetActive(true);
        }



    }

}
