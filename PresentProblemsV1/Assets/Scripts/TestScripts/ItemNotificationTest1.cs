using System.Collections;
using UnityEngine;

public class ItemNotificationTest1 : MonoBehaviour
{
    public GameObject ItemNotifySprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ItemNotifySprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator NotifyItemGot()
    {
        ItemNotifySprite.SetActive(true);

        yield return new WaitForSeconds(1.5f);

    }


}
