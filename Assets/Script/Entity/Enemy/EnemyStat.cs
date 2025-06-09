using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat
{
    public float curHp;
    public float maxHp;

    public EnemyStat(EnemyDataSo data)
    {
        maxHp = data.hp;
        curHp = maxHp;

    }
}
