using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class TestMovement : MonoBehaviour
{

    /*public Transform player;
    public float moveSpeed;
    public float moveAccuracy;*/

    public NavMeshAgent agent;
    public Vector2 GoToLocation;
    public Camera Cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        GoToLocation = transform.position;


        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "WalkingTest1")
        {
            if (SceneChecks.FromChimney)
            {
                Cam.transform.position = new Vector3(30, 0, -10);
                agent.ResetPath();
                agent.Warp(new Vector3(25, -0.45f, 0));
                GoToLocation = transform.position;
                SceneChecks.FromChimney = false;
            }
            else
            {
                Cam.transform.position = new Vector3(0, 0, -10);
                agent.ResetPath();
                agent.Warp(new Vector3(0, -1.84f, 0));
                GoToLocation = transform.position;
            }




        }
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            GoToLocation = new Vector2(mousePos.x, mousePos.y);
        }
        agent.SetDestination(new Vector3(GoToLocation.x, GoToLocation.y, transform.position.z));


    }


    public void InteractButton()
    {
        Debug.Log("test");
    }

    /*public void newroom()
    {
        agent.ResetPath();
        //Debug.Log("test");
        agent.SetDestination(new Vector3(transform.position.x, transform.position.y, transform.position.z));

    }

    public IEnumerator MoveToPoint(Vector2 point)
    {
        Vector2 positionDifference = point - (Vector2)player.position;
        while (positionDifference.magnitude > moveAccuracy)
        {
            player.Translate(moveSpeed * positionDifference.normalized * Time.deltaTime);
            yield return null;
        }

        yield return null;
    }*/


}
