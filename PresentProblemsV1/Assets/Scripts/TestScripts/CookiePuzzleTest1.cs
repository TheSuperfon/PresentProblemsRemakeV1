using UnityEngine;
using UnityEngine.SceneManagement;

public class CookiePuzzleTest1 : MonoBehaviour
{
    public Vector3 CookieCameraPOS;
    public Camera Camera;
    public SceneTransition SceneTransitionScript;
    //public string PowderName;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CookiePuzzlePowderCheck(string PowderName)
    {
        if (Camera.transform.position == CookieCameraPOS)
        {
            if (PowderName == "Peanut") //possibly use scenetransition with powderName (Sugar cutscene could start back here)
            {
                SceneTransitionScript.LoadScene("PeanutEnding");
            }
            else if (PowderName == "Pepper")
            {
                SceneTransitionScript.LoadScene("PepperEnding");
            }
            else
            {
                Debug.Log("Continue");
            }






        }


    }



}
