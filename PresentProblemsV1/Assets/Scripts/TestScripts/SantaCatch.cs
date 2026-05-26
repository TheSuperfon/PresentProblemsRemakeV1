using UnityEngine;

public class SantaCatch : MonoBehaviour
{

    public float CatchNumb;
    public float CatchCap;
    public Camera Cam;
    bool done;

    public Vector3 CatchBack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CatchNumb = 0;
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!done && (SceneChecks.CouchWarning == false))
        {
            Debug.Log(SceneChecks.CouchWarning);
            if (CatchNumb < 3)
            {
                collision.gameObject.GetComponent<TestMovement>().GoToLocation = CatchBack;
                CatchNumb += 1;
            }
            else
            {
                Debug.Log("caught");

            }

            

            //Debug.Log("ok");
        }
        
        //Debug.Log("thing")

    }

    public void ToyWithSanta()
    {
        if (Cam.transform.position == new Vector3(30, 0, -10))
        {
            SceneChecks.CouchWarning = true;
            Debug.Log("toy");
        }

        Debug.Log(SceneChecks.CouchWarning);

    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (SceneChecks.CouchWarning == false)
        {
            collision.gameObject.GetComponent<TestMovement>().GoToLocation = CatchBack;
        }

        


    }


    private void OnTriggerExit(Collider other)
    {
        done = false;
    }

}
