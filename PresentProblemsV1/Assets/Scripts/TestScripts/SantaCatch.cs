using UnityEngine;

public class SantaCatch : MonoBehaviour
{

    public float CatchNumb;
    public float CatchCap;
    public Camera Cam;
    bool done;

    public Vector3 CatchBack;

    public GameObject CutsceneObj;

    public Animator SantaAnim;
    public OverlapScreenScript OverlapScreenScript;
    //public bool playCutscene;
    public GameObject DinoCutscene;
    public GameObject BlockCutscene;
    //public bool IsDinoToy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CatchNumb = 0;
        done = false;
        CutsceneObj.SetActive(false);
        OverlapScreenScript.activeScript = false;
        DinoCutscene.SetActive(false);
        BlockCutscene.SetActive(false);
        //playCutscene = false;
        
    }

    /*public void PlayDino()
    {
        if (playCutscene)
        {
            DinoCutscene.SetActive(true);
            Debug.Log("DinoTime");
        }
        Debug.Log("too Dino");
    }*/

    /*public void PlayBlock()
    {
        if (playCutscene)
        {
            BlockCutscene.SetActive(true);
        }
    }*/


    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!done && (SceneChecks.CouchWarning == false))
        {
            SantaAnim.SetBool("CatchBool", true);
            Debug.Log(SceneChecks.CouchWarning);
            if (CatchNumb < CatchCap)
            {
                collision.gameObject.GetComponent<TestMovement>().GoToLocation = CatchBack;
                CatchNumb += 1;
                
            }
            else
            {
                CutsceneObj.SetActive(true);
                CutsceneObj.transform.GetChild(1).transform.gameObject.SetActive(true);
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
            //Debug.Log("toy");
            //playCutscene = true;
            OverlapScreenScript.activeScript = true;

            if (SceneChecks.DinoChoice)
            {
                DinoCutscene.SetActive(true);
            }
            else
            {
                BlockCutscene.SetActive(true);
            }


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
