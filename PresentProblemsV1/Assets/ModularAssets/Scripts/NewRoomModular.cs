using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewRoomModular : MonoBehaviour
{
    public Vector2 Newspawn;
    public Vector3 CameraNewPos;
    public Camera Cam;
    public SceneAsset SceneAsset;
    
    public bool SceneBool;
    public bool higherGround;
    bool lookat;

    public bool IsStairs = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lookat = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (higherGround)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lookat = true;

            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneBool == true)
        {
            if (IsStairs)
            {
                SceneChecks.TakingStares = true;
            }
            SceneTransition();

        }
        else
        {
            if (higherGround == true)
            {
                if (lookat == true)
                {
                    collision.gameObject.GetComponent<TestMovement>().agent.ResetPath();

                    collision.gameObject.GetComponent<TestMovement>().agent.Warp(new Vector3(Newspawn.x, Newspawn.y, transform.position.z));

                    collision.gameObject.GetComponent<TestMovement>().GoToLocation = Newspawn;

                    //collision.gameObject.GetComponent<TestMovement>().newroom();
                    Cam.transform.position = CameraNewPos;
                    //Debug.Log("why");
                    lookat = false;
                }

            }
            else
            {
                collision.gameObject.GetComponent<TestMovement>().agent.ResetPath();

                collision.gameObject.GetComponent<TestMovement>().agent.Warp(new Vector3(Newspawn.x, Newspawn.y, transform.position.z));

                collision.gameObject.GetComponent<TestMovement>().GoToLocation = Newspawn;

                //collision.gameObject.GetComponent<TestMovement>().newroom();
                Cam.transform.position = CameraNewPos;
                //Debug.Log("why");
            }


        }




    }





    public void SceneTransition()
    {
        
        SceneManager.LoadScene(SceneAsset.name);


    }


}
