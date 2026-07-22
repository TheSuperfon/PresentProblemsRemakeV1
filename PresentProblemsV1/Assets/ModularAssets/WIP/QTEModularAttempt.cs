using System.Collections;
using NUnit.Framework;
using UnityEditor.Build.Content;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Video;

public class QTEModularAttempt : MonoBehaviour
{
    public RectTransform QTEObj;
    //public RectTransform QTERect;
    public float RepeatNum;
    float CurrentNum;
    public bool activateQTE;
    float timer;
    public float QTETimeValue;
    int LocationChoice; //0 = up 1 = left, 2 = right, 
    public SceneTransition sceneReference;
    public string SceneNext;
    public string ScenePrevious;

    int prepareloop = 0;
    bool prepared;

    [SerializeField] public List<Vector3> locations = new();
    [SerializeField] public List<GameObject> cutsceneList = new();

    //[SerializeField] public Dictionary<Vector3,GameObject> locationDict = new();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        prepared = false;
        prepareloop = 0;
        SceneChecks.QTECompleted = false;
        SceneChecks.QTEFailed = false;
        timer = QTETimeValue;
        LocationChoice = Random.Range(0, 3);
        activateQTE = true;
        CurrentNum = 0;

        StartCoroutine(cutscenePrepare());
    }

    public IEnumerator cutscenePrepare()
    {
        for (int i = 0; i < cutsceneList.Count; i++)
        {

            cutsceneList[i].SetActive(true);
            cutsceneList[i].GetComponentInChildren<VideoPlayer>().Prepare();


            while (!cutsceneList[i].GetComponentInChildren<VideoPlayer>().isPrepared)
            {
                cutsceneList[i].GetComponentInChildren<VideoPlayer>().Prepare();
                cutsceneList[i].GetComponentInChildren<VideoPlayer>().prepareCompleted += OnPrepareCompleted;
                yield return null;

            }
            cutsceneList[i].SetActive(false);
            //cutsceneList[i].GetComponentInChildren<VideoPlayer>().prepareCompleted += OnPrepareCompleted;
            //Debug.Log("gogo");
            /*prepareloop += 1;
            if (prepareloop >= cutsceneList.Count)
            {
                prepared = true;
            }*/
        }


    }


    void OnPrepareCompleted(VideoPlayer vp)
    {
        //prepareloop += 1;
        Debug.Log("prepare");
        // Preparation is complete so allow interactions with the play button. 
        prepareloop += 1;
        if (prepareloop >= cutsceneList.Count)
        {
            prepared = true;
        }
    }





    // Update is called once per frame
    void Update()
    {

        if (activateQTE && prepared)
        {




            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log(LocationChoice);
                QTEObj.gameObject.SetActive(false);
                cutsceneList[LocationChoice].gameObject.SetActive(false);
                cutsceneList[LocationChoice].GetComponentInChildren<VideoPlayer>().time = 0;

                timer = QTETimeValue;
                LocationChoice = Random.Range(0, 3);
                //Debug.Log("success");
                CurrentNum += 1;

                if (CurrentNum >= RepeatNum)
                {
                    activateQTE = false;
                    SceneChecks.QTECompleted = true;
                    SceneChecks.FromChimney = true;
                    cutsceneList[3].gameObject.SetActive(true);
                    //sceneReference.LoadScene(SceneNext);

                }
            }
        }





    }


    public void buttonPressed()
    {

    }


    private void FixedUpdate()
    {



        if (activateQTE && prepared)
        {
            if (!QTEObj.gameObject.activeInHierarchy)
            {
                QTEObj.gameObject.SetActive(true);
                QTEObj.anchoredPosition = locations[LocationChoice];
                if (LocationChoice == 0 || LocationChoice == 2)
                {
                    int choice = Random.Range(0, 2);
                    cutsceneList[choice].gameObject.SetActive(true);
                    cutsceneList[choice].gameObject.GetComponentInChildren<VideoPlayer>().Play();

                }
                else
                {
                    cutsceneList[LocationChoice].gameObject.SetActive(true);
                    cutsceneList[LocationChoice].gameObject.GetComponentInChildren<VideoPlayer>().Play();

                }


            }
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                QTEObj.gameObject.SetActive(false);
                activateQTE = false;
                timer = QTETimeValue;
                LocationChoice = Random.Range(0, 3);
                //Debug.Log("Fail");
                SceneChecks.QTEFailed = false;
                //sceneReference.LoadScene("UpstairsTest1");
                cutsceneList[2].gameObject.SetActive(true);
            }




        }

    }
}
