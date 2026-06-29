using UnityEngine;

public class HighlightingOverlap : MonoBehaviour
{
    bool Highlighted;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Highlighted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        Debug.Log("wwww");
        Highlighted = true;
    }

    private void OnMouseExit()
    {
        Highlighted = false;
    }

}
