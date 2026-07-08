using Unity.VisualScripting;
using UnityEngine;

public class HighlightingOverlap : MonoBehaviour
{
    public bool Highlighted;
    public bool transparent = false;
    public GameObject arrow;
    Material material;

    public GameObject interfere;

    public float ThickOutline;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Highlighted = false;

        if (!transparent)
        {
            material = GetComponent<SpriteRenderer>().material;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Highlighted)
        {

            //Debug.Log("RRR");
        }

        if (!transparent)
        {
            interfere.
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
        
        if (!transparent)
        {
            material.SetFloat("_OutlineThickness", ThickOutline);
        }
        else
        {
            arrow.SetActive(true);
        }
        

    }

    private void OnMouseExit()
    {
        
        Highlighted = false;


        if (!transparent)
        {
            material.SetFloat("_OutlineThickness", 0f);
        }
        else
        {
            arrow.SetActive(false);
        }
        
    }

}
