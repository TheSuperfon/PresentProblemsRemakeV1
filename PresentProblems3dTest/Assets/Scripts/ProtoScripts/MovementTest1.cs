using UnityEngine;
using UnityEngine.AI;

public class MovementTest1 : MonoBehaviour
{

    public NavMeshAgent agent;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();



    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                move(hit.point);
            }


        }


    }

    void move(Vector3 point)
    {

        agent.SetDestination(point);
        //Debug.Log("oof");

    }





}
