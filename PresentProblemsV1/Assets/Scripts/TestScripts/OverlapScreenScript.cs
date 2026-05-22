using UnityEngine;

public class OverlapScreenScript : MonoBehaviour
{
    public Camera Cam;
    public Vector3 CameraNewPos;
    public Vector3 LastCameraPos;
    public bool LookAt;

    GameObject playerRef;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LookAt = false;
    }

    private void OnMouseOver()
    {
        //Debug.Log("over");
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
            playerRef = collision.gameObject;
            playerRef.GetComponent<TestMovement>().enabled = false;

            LastCameraPos = Cam.transform.position;

            Cam.transform.position = CameraNewPos;

        }




    }

    public void OutOfOverlapScreen()
    {
        playerRef.gameObject.GetComponent<TestMovement>().enabled = true;

        Cam.transform.position = LastCameraPos;

    }


}
