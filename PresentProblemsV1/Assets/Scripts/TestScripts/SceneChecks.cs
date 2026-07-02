using UnityEngine;

public class SceneChecks : MonoBehaviour
{
    public static bool QTECompleted = false;
    public static bool QTEFailed = false;
    public static bool FromChimney = false;

    public static bool DinoChoice = true;
    public static bool toyActive = false;

    public static bool FireplaceSantaCheck = false;
    public static bool CouchWarning = false;
    public static bool inventoryEmpty = true;
    public static float PresentCheck = 0f;
    public static float StockingCheck = 0f;

    public static bool TakingStares = false;

    public static bool SeenCutscene = false;


    public static void StartReset()
    {
        QTECompleted = false;
        QTEFailed = false;
        FromChimney = false;
        DinoChoice = false;
        toyActive = false;
        FireplaceSantaCheck = false;
        CouchWarning = false;
        inventoryEmpty = true;
        PresentCheck = 0f;
        StockingCheck = 0f;
        TakingStares = false;
        SeenCutscene = false;

    }

}
