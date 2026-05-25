using System.Collections;
using NUnit.Framework;
using UnityEditor.Build.Content;
using UnityEngine;
using System.Collections.Generic;
//using UnityEngine.Windows;

public class QTETestScript : MonoBehaviour
{

    public GameObject QTEObj;
    public float RepeatNum;
    float CurrentNum;
    public bool activateQTE;
    float timer;
    public float QTETimeValue;
    int LocationChoice; //0 = up 1 = left, 2 = right, 
    public SceneTransition sceneReference;

    [SerializeField] public List<Vector3> locations = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneChecks.QTECompleted = false;
        SceneChecks.QTEFailed = false;
        timer = QTETimeValue;
        LocationChoice = Random.Range(0, 3);
        activateQTE = true;
        CurrentNum = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (activateQTE)
        {




            if (Input.GetKeyDown(KeyCode.A))
            {

                QTEObj.SetActive(false);

                timer = QTETimeValue;
                LocationChoice = Random.Range(0, 3);
                Debug.Log("success");
                CurrentNum += 1;

                if (CurrentNum >= RepeatNum)
                {
                    activateQTE = false;
                    SceneChecks.QTECompleted = true;
                    SceneChecks.FromChimney = true;
                    sceneReference.LoadScene("WalkingTest1");
                }
            }
        }



        

    }

    private void FixedUpdate()
    {

        

        if (activateQTE)
        {
            if (!QTEObj.activeInHierarchy)
            {
                QTEObj.SetActive(true);
                QTEObj.transform.position = locations[LocationChoice];
            }
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                QTEObj.SetActive(false);
                activateQTE = false;
                timer = QTETimeValue;
                LocationChoice = Random.Range(0, 3);
                //Debug.Log("Fail");
                SceneChecks.QTEFailed = false;
                sceneReference.LoadScene("UpstairsTest1");
            }

            


        }

    }


    


}
