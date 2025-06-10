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

    public SlotUI slotUI;


    
    public Slot(ItemData itemData)
    {
        this.itemData = itemData;
    }

    
    public void EquipItem()
    {
        isEquip = true;
        EventBus.Publish("AddItemStatEvent", itemData);
        EventBus.Subscribe("UnEquipEvent", UnEquipItem);
    }

    public void UnEquipItem(object obj)
    {
        Slot slot = (Slot)obj;
        if (isEquip == true)
        {
            //EventBus.Publish("ReduceStat", itemData);
            ReduceStat(itemData);
            isEquip = false;
        }
    }
    public void ReduceStat(object obj)
    {
        ItemData data = (ItemData)obj;

        //구독해제
        EventBus.Unsubscribe("UnEquipEvent", UnEquipItem);
        //스텟변경 호출
        EventBus.Publish("ReduceItemStatEvent", data);

    }

}

