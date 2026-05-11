using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;


public class TransitionScreenTest : MonoBehaviour
{
    public Vector2 Newspawn;
    public Vector3 CameraNewPos;
    public Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.gameObject.GetComponent<TestMovement>().agent.ResetPath();

        collision.gameObject.GetComponent<TestMovement>().agent.Warp( new Vector3(Newspawn.x, Newspawn.y, transform.position.z));

        collision.gameObject.GetComponent<TestMovement>().GoToLocation = Newspawn;

        //collision.gameObject.GetComponent<TestMovement>().newroom();
        cam.transform.position = CameraNewPos;
        //Debug.Log("why");


    }




}
