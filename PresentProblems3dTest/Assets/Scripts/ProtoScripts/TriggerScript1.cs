using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using NUnit.Framework;

public class TriggerScript1 : MonoBehaviour
{
    public bool sceneChange;

    public Vector3 Newspawn;
    public Vector3 CameraNewPos;
    public float CamRotationVal;
    public Camera Cam;
    public string SceneToLoad;

    //public List<GameObject[]> d;
    public GameObject[] Hideable;
    public GameObject[] UnHideables;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (sceneChange == true)
        {
            SceneTransition();
        }
        else
        {
            collision.gameObject.GetComponent<MovementTest1>().agent.ResetPath();

            collision.gameObject.GetComponent<MovementTest1>().agent.Warp(new Vector3(Newspawn.x, Newspawn.y, Newspawn.z));

            collision.gameObject.GetComponent<MovementTest1>().agent.SetDestination(Newspawn);



            //collision.gameObject.GetComponent<TestMovement>().newroom();
            Cam.transform.position = CameraNewPos;

            //Cam.transform.Rotate(0,CamRotationVal,0);

            Cam.transform.rotation = Quaternion.Euler(0, CamRotationVal, 0);

            //Debug.Log("why");

            if (Hideable.Length > 0)
            {
                for (int i = 0; i < Hideable.Length; i++)
                {
                    Hideable[i].gameObject.SetActive(false);
                }

            }

            if (UnHideables.Length > 0)
            {
                for (int i = 0; i < Hideable.Length; i++)
                {
                    UnHideables[i].gameObject.SetActive(true);
                }

            }

        }



    }

    public void SceneTransition()
    {
        //SceneToLoad = SceneName;
        SceneManager.LoadScene(SceneToLoad);


    }


}
