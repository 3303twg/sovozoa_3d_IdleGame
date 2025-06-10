using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ItemData
{
    public string itemName;
    public string itemInfo;
    public GameObject itemPrefab;
    public Sprite icon;
    public bool isEquip;
    public bool isStackable;
    public int cnt;
    public int maxCnt;
    public int goldValue;

    [Header("���ݷ�")]
    public float attackPower;
    [Header("���ݼӵ� ex)1.2����")]
    public float attackSpeed;
    [Header("ũ��Ȯ�� ex)~~%")]
    public float criticalChance;
    [Header("ũ������ ex)1.2����")]
    public float criticalRatio;
    [Header("���߷� ex)~~%")]
    public float accuracy;

    public ItemData(ItemDataSo dataSo)
    {
        this.cnt = dataSo.cnt;
        this.maxCnt = dataSo.maxCnt;
        this.isStackable = dataSo.isStackable;
        this.goldValue = dataSo.goldValue;

        this.itemName = dataSo.itemname;
        this.itemInfo = dataSo.itemInfo;
        this.itemPrefab = dataSo.itemPrefab;
        this.icon = dataSo.icon;
        WeaponData data = dataSo.weapon;

        this.isEquip = data.isEquip;
        this.attackPower = data.attackPower;
        this.attackSpeed = data.attackSpeed;
        this.criticalChance = data.criticalChance;
        this.criticalRatio = data.criticalRatio;
        this.accuracy = data.accuracy;
    }
}
