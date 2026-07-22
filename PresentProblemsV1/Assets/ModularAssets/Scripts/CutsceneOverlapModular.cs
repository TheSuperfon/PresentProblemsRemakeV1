using UnityEngine;
using UnityEngine.Video;

public class CutsceneOverlapModular : MonoBehaviour
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

    public string staticValueName = "Couch";

    public bool resetable;

    public bool skipable = false;

    bool NoLoop;
    public bool BackToBack = false;
    public GameObject nextscene;

    //scenechecks is a public script that has a ton of static variables that are used for reference



    void Start()
    {
        NoLoop = true;
        videoPlayer = GetComponent<VideoPlayer>();
        videoActive = false;

        if (OneAndDone)
        {

            if (staticValueName == "Couch" && SceneChecks.SeenCutscene == true)
            {
                screen.SetActive(false);
                videoPlayer.Stop();
            }
            else if (staticValueName == "Intro" && SceneChecks.seenIntro == true)
            {
                screen.SetActive(false);
                videoPlayer.Stop();
            }



        }
        else
        {
            screen.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (((staticValueName == "Couch" && SceneChecks.SeenCutscene == false) || (staticValueName == "Intro" && SceneChecks.seenIntro == false)) && !videoPlayer.isPlaying)
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

            if (staticValueName == "Couch")
            {
                SceneChecks.SeenCutscene = true;
            }
            else if (staticValueName == "Intro")
            {
                SceneChecks.seenIntro = true;
            }

        }
        videoPlayer.loopPointReached += EndReached;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (videoPlayer.isPlaying && skipable)
            {
                videoPlayer.Stop();
                EndReached(videoPlayer);
            }

        }
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        if (StopPlayer)
        {
            playerRef.GetComponent<TestMovement>().enabled = true;
        }

        if (FinishedSceneTransition && NoLoop)
        {
            sceneTransition.LoadScene(sceneName);
            NoLoop = false;
        }

        if (!BackToBack)
        {
            screen.SetActive(false);

        }
        else
        {
            //reset video
            if (NoLoop)
            {
                //videoPlayer.frame = 0;
                videoPlayer.Stop();
                NoLoop = false;
            }

            if (nextscene != null)
            {
                screen.SetActive(false);
                nextscene.SetActive(true);
            }

        }


    }
}
