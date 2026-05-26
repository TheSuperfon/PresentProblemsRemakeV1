using UnityEngine;

public class ToyPickup : MonoBehaviour
{

    public PauseAttempt1 InventoryReference;
    public GameObject dinoOBJ;
    public GameObject blocksOBJ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneChecks.DinoChoice)
        {
            blocksOBJ.SetActive(false);
            dinoOBJ.SetActive(true);
        }
        else
        {
            blocksOBJ.SetActive(true);
            dinoOBJ.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (SceneChecks.DinoChoice)
            {
                InventoryReference.activateDino();
            }
            else
            {
                InventoryReference.activateBlocks();
            }



        }


    }

}
