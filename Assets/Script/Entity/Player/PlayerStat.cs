using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStat
{
    [Header("공격력")]
    public float attackPower = 1f;
    [Header("공격속도")]
    public float attackSpeed = 1f;
    [Header("크리확률")]
    public float criticalChance = 5f;
    [Header("크리배율")]
    public float criticalRatio = 1.2f;
    [Header("명중률")]
    public float accuracy = 80f;

    public string attackType;
}
