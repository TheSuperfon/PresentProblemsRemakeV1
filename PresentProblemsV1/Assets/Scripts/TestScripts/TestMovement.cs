using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class TestMovement : MonoBehaviour
{

    /*public Transform player;
    public float moveSpeed;
    public float moveAccuracy;*/

    public NavMeshAgent agent;
    public Vector2 GoToLocation;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        GoToLocation = transform.position;
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

    public void newroom()
    {
        agent.ResetPath();
        Debug.Log("test");
        agent.SetDestination(new Vector3(transform.position.x, transform.position.y, transform.position.z));

    }

    /*public IEnumerator MoveToPoint(Vector2 point)
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
