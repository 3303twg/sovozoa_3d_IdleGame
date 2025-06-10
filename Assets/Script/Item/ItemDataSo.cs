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
    [Header("공격력")]
    public float attackPower;
    [Header("공격속도 ex)1.2배율")]
    public float attackSpeed;
    [Header("크리확률 ex)~~%")]
    public float criticalChance;
    [Header("크리배율 ex)1.2배율")]
    public float criticalRatio;
    [Header("명중률 ex)~~%")]
    public float accuracy;
}
