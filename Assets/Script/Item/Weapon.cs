using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
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
