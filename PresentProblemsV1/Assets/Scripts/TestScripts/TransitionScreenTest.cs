using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;


public class TransitionScreenTest : MonoBehaviour
{
    public Vector2 Newspawn;
    public Vector3 CameraNewPos;
    public Camera Cam;
    public string SceneToLoad;

    public bool SceneBool;
    public bool higherGround;
    bool lookat;

    //public NavMeshAgent NavMeshAgent;

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
            SceneTransition(SceneToLoad);
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

    

    

    public void SceneTransition(string SceneName)
    {
        //SceneToLoad = SceneName;
        SceneManager.LoadScene(SceneName);


    }


}
