using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransition : MonoBehaviour
{
    //public string SceneToLoad;

    public GameObject Menu;
    public GameObject Splash;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);


    }

    public void QuitScene()
    {
        Application.Quit();
    }


    public void SplashScreen()
    {
        Menu.SetActive(false);
        Splash.SetActive(true);


    }


}
