using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MovementPointClick : MonoBehaviour
{

    
    public NavMeshAgent agent;
    public Vector2 GoToLocation;
    public Camera Cam;

    private Animator animator;

    private Vector2 StuckDistance;

    bool updateAnimate = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateAnimate = false;
        animator = GetComponentInChildren<Animator>();

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
            updateAnimate = true;
        }
        agent.SetDestination(new Vector3(GoToLocation.x, GoToLocation.y, transform.position.z));

        UpdateAnimation();
    }


    void UpdateAnimation()
    {
        if (updateAnimate)
        {
            if (transform.position.x < GoToLocation.x) //to the right
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            updateAnimate = false;
        }
        

        float distance = Vector2.Distance(transform.position, GoToLocation);

        if (Vector2.Distance(StuckDistance, transform.position) == 0) { animator.SetFloat("distance", 0f);  return; }

        animator.SetFloat("distance", distance);
        if (distance > 0.01)
        {
            Vector3 direction = transform.position - new Vector3(GoToLocation.x, GoToLocation.y, transform.position.z);
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            animator.SetFloat("angle", angle);
            StuckDistance = transform.position;

            


        }


        
    }

    

}
