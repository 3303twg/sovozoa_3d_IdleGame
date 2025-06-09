using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
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

    public Weapon(ItemDataSo dataSo)
    {
        WeaponData data = dataSo.weapon;

        this.isEquip = data.isEquip;
        this.attackPower = data.attackPower;
        this.attackSpeed = data.attackSpeed;
        this.criticalChance = data.criticalChance;
        this.criticalRatio = data.criticalRatio;
        this.accuracy = data.accuracy;
    }
}
