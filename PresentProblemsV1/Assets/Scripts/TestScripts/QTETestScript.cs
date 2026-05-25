using System.Collections;
using NUnit.Framework;
using UnityEditor.Build.Content;
using UnityEngine;
using System.Collections.Generic;
//using UnityEngine.Windows;

public class QTETestScript : MonoBehaviour
{

    public GameObject QTEObj;
    public bool activateQTE;
    float timer;
    public float QTETimeValue;
    int LocationChoice; //0 = up 1 = left, 2 = right, 

    [SerializeField] public List<Vector3> locations = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = QTETimeValue;
        LocationChoice = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }

    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            activateQTE = true;
            Debug.Log("E");
        }

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
                Debug.Log("Fail");
            }

            if (Input.GetKey(KeyCode.A))
            {
                QTEObj.SetActive(false);
                activateQTE = false;
                timer = QTETimeValue;
                LocationChoice = Random.Range(0, 3);
                Debug.Log("success");
            }


        }

    }


    


}
