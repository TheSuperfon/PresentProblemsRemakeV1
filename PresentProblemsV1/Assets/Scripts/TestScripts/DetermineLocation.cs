using UnityEngine;
using UnityEngine.AI;

public class DetermineLocation : MonoBehaviour
{
    public GameObject player;
    public Vector3 firstLocation;
    public Vector3 secondLocation;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {




        StartingLocation();

    }

    public void StartingLocation()
    {
        if (SceneChecks.TakingStares)
        {
            player.GetComponent<NavMeshAgent>().ResetPath();
            player.GetComponent<NavMeshAgent>().Warp(secondLocation);
            player.GetComponent<TestMovement>().GoToLocation = secondLocation;
            SceneChecks.TakingStares = false;
        }
        else
        {
            player.GetComponent<NavMeshAgent>().ResetPath();
            player.GetComponent<NavMeshAgent>().Warp(firstLocation);
            player.GetComponent<TestMovement>().GoToLocation = firstLocation;
        }


    }


}
