using TMPro;
using UnityEngine;

public class ToyPickup : MonoBehaviour
{

    public PauseAttempt1 InventoryReference;
    public GameObject dinoOBJ;
    public GameObject blocksOBJ;
    bool GoingToToy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GoingToToy = false;
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
        Debug.Log("eee");
        if (Input.GetMouseButtonDown(0))
        {

            GoingToToy = true;

            



        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GoingToToy)
        {
            if (SceneChecks.DinoChoice)
            {
                InventoryReference.activateDino();
                dinoOBJ.SetActive(false);
            }
            else
            {
                InventoryReference.activateBlocks();
                blocksOBJ.SetActive(false);
            }
        }



    }

}
