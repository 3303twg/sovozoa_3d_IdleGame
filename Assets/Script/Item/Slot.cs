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
            //��������
            EventBus.Unsubscribe("UnEquipEvent", ReduceStat);
            //���ݺ��� ȣ��
            EventBus.Publish("ReduceItemStatEvent", itemData);
        }
    }

}

