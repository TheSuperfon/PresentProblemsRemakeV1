using System.Collections;
using TMPro;
using UnityEngine;

public class OverlapScreenScript : MonoBehaviour
{
    public Camera Cam;
    public Vector3 CameraNewPos;
    public Vector3 LastCameraPos;
    public bool LookAt;

    public GameObject playerRef;
    //public SpriteRenderer Highlight;
    public bool activeScript = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LookAt = false;
        //Highlight.color = new Color(Highlight.color.r, Highlight.color.g, Highlight.color.b, 0);
    }

    private void OnMouseOver()
    {
        //Debug.Log("over");
        if (Input.GetMouseButtonDown(0))
        {
            LookAt = true;

        }

        //StartCoroutine(DoAThingOverTime(new Color(Highlight.color.r, Highlight.color.g, Highlight.color.b, 0), new Color(Highlight.color.r, Highlight.color.g, Highlight.color.b, 100), 3));
    }

    private void OnMouseEnter()
    {
        
    }

    private void OnMouseExit()
    {
        //Highlight.color = new Color(Highlight.color.r, Highlight.color.g, Highlight.color.b, 0);
    }

    

    IEnumerator DoAThingOverTime(Color start, Color end, float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;
            //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
            //Highlight.color = Color.Lerp(start, end, normalizedTime);

            yield return null;
        }
        //Highlight.color = end; //without this, the value will end at something like 0.9992367
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (LookAt)
        {
            //playerRef = collision.gameObject;
            if (activeScript)
            {
                playerRef.GetComponent<TestMovement>().enabled = false;
                //Debug.Log(playerRef);

                LastCameraPos = Cam.transform.position;

                Cam.transform.position = CameraNewPos;
                //activeScript = false;
                //LookAt = false;
            }

        }




    }

    public void OutOfOverlapScreen()
    {
        if (activeScript)
        {
            playerRef.gameObject.GetComponent<TestMovement>().enabled = true;

            Cam.transform.position = LastCameraPos;

        }
        //Debug.Log(playerRef);

    }


}
