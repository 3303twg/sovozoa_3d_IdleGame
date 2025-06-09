using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStat
{
    [Header("���ݷ�")]
    public float attackPower = 1f;
    [Header("���ݼӵ�")]
    public float attackSpeed = 1f;
    [Header("ũ��Ȯ��")]
    public float criticalChance = 5f;
    [Header("ũ������")]
    public float criticalRatio = 1.2f;
    [Header("���߷�")]
    public float accuracy = 80f;

    public string attackType;
}
