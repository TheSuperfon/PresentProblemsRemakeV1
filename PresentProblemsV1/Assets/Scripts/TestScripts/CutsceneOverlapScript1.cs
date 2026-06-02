using UnityEngine;
using UnityEngine.Video;

public class CutsceneOverlapScript1 : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public TestMovement playerRef;
    bool videoActive = false;
    public GameObject screen;

    public SceneTransition sceneTransition;

    public bool StopPlayer;
    public bool FinishedSceneTransition;
    public string sceneName;
    public bool OneAndDone;

    bool NoLoop;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NoLoop = true;
        videoPlayer = GetComponent<VideoPlayer>();
        videoActive = false;

        if (OneAndDone && SceneChecks.SeenCutscene == true)
        {
            screen.SetActive(false);
            videoPlayer.Stop();
        }
        else
        {
            screen.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneChecks.SeenCutscene == false && !videoPlayer.isPlaying)
        {
            videoPlayer.Play();
            videoActive = true;
            if (StopPlayer)
            {
                playerRef.GetComponent<TestMovement>().enabled = false;
            }
            
        }
        if (!videoPlayer.isPlaying && videoActive)
        {
            //Debug.Log("finished");
            videoActive = false;
            SceneChecks.SeenCutscene = true;

        }
        videoPlayer.loopPointReached += EndReached;

    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("fish");
        if (StopPlayer)
        {
            playerRef.GetComponent<TestMovement>().enabled = true;
        }
        
        if (FinishedSceneTransition && NoLoop)
        {
            sceneTransition.LoadScene(sceneName);
            NoLoop = false;
        }


        screen.SetActive(false);
    }


    public void oof(UnityEngine.Video.VideoPlayer vp)
    {

    }









}
