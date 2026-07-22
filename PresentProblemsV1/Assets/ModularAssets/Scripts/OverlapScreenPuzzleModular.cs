using System.Collections;
using TMPro;
using UnityEngine;
public class OverlapScreenPuzzleModular : MonoBehaviour
{
    public Camera Cam;
    public Vector3 CameraNewPos;
    public Vector3 LastCameraPos;
    public bool LookAt;

    public GameObject playerRef;
    public bool activeScript = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LookAt = false;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LookAt = true;

        }
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

    }
}
