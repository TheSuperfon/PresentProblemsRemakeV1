using UnityEngine;

public class PauseAttempt1 : MonoBehaviour
{
    public bool inventoryOut;
    public GameObject InventoryOBJ;
    public GameObject dino;
    public GameObject block;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryOut = false;

        if (SceneChecks.toyActive)
        {
            if (SceneChecks.DinoChoice)
            {
                activateDino();
            }
            else
            {
                activateBlocks();
            }


        }
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

    public void activateDino()
    {
        dino.SetActive(true);
        SceneChecks.toyActive = true;
    }


    public void activateBlocks()
    {
        block.SetActive(true);
        SceneChecks.toyActive = true;
    }



}
