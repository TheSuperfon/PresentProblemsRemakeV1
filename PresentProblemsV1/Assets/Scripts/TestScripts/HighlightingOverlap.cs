using UnityEngine;

public class HighlightingOverlap : MonoBehaviour
{
    bool Highlighted;
    Material material;

    public float ThickOutline;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Highlighted = false;
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        Debug.Log("wwww");
        Highlighted = true;

        material.SetFloat("ThicknessOutline", ThickOutline);

    }

    private void OnMouseExit()
    {
        Highlighted = false;
        material.SetFloat("ThicknessOutline", 0f);
    }

}
