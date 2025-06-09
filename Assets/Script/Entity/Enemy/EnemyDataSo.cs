using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "EnemyData", menuName = "Enemy")]
public class EnemyDataSo : ScriptableObject
{
    public string name;
    public float hp;
    public GameObject enemyPrefab;
    //List<Item>asdhiaifa?
    public DropTable dropTable;
}


[Serializable]
public class DropTable
{
    public int gold;
    public int exp;
    public List<ItemDataSo> item;
}
