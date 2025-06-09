using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemDataSo itemDataSo;
    public ItemData itemdata;
    void Start()
    {
        itemdata = new ItemData(itemDataSo);
        Invoke("GetItem", 1f);
    }

    public void GetItem()
    {
        Debug.Log("??");
        EventBus.Publish("AddItemEvent", itemdata);
        Destroy(gameObject);
    }
}
