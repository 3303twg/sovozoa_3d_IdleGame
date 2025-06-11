using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyStat
{
    public float curHp;
    public float maxHp;
    public DropTable dropTable;

    public EnemyStat(EnemyDataSo data)
    {
        maxHp = data.hp;
        curHp = maxHp;
        dropTable = data.dropTable;

    }
}
