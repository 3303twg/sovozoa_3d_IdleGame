using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Itme")]
public class ItemDataSo : ScriptableObject
{
    public string itemname;
    public string itemInfo;
    public GameObject itemPrefab;
    public Sprite icon;

    public bool isStackable;
    public int cnt;
    public int maxCnt;

    public int goldValue;

    [SerializeField]
    public WeaponData weapon;
}

[Serializable]
public class WeaponData
{
    public bool isEquip;
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
}
