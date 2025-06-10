using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class Slot
{
    //�ߺ�ȹ���� ����ɵ�?
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

        //��������
        EventBus.Unsubscribe("UnEquipEvent", UnEquipItem);
        //���ݺ��� ȣ��
        EventBus.Publish("ReduceItemStatEvent", data);

    }

}

