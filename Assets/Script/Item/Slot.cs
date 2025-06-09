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
    
}

