using Unity.VisualScripting;
using UnityEngine;

public class HighlightingOverlap : MonoBehaviour
{
    public bool Highlighted;
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
        /*if (Highlighted)
        {

            //Debug.Log("RRR");
        }*/
    }

    private void OnMouseOver()
    {
        //Debug.Log("eeeeeeeeeeee");
    }

    private void OnMouseEnter()
    {
        //Debug.Log("wwww");
        Highlighted = true;
        

        material.SetFloat("_OutlineThickness", ThickOutline);

    }

    private void OnMouseExit()
    {
        Highlighted = false;
        material.SetFloat("_OutlineThickness", 0f);
    }

}
