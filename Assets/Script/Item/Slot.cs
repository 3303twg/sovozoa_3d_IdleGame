using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class Slot
{
    //중복획득은 없어도될듯?
    [SerializeField]
    public ItemData itemData;
    public bool isEquip = false;


    
    public Slot(ItemData itemData)
    {
        this.itemData = itemData;
    }

    
    public void EquipItem()
    {
        isEquip = true;
        EventBus.Publish("AddItemStatEvent", itemData);
        EventBus.Subscribe("UnEquipEvent", ReduceStat);
    }
    public void ReduceStat(object obj)
    {
        Slot slot = (Slot)obj;
        if (slot != this)
        {
            isEquip = false;
            //구독해제
            EventBus.Unsubscribe("UnEquipEvent", ReduceStat);
            //스텟변경 호출
            EventBus.Publish("ReduceItemStatEvent", itemData);
        }
    }

}

