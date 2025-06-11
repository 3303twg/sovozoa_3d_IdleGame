using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "StageData")]
public class StageDataSo : ScriptableObject
{
    public int stageID;
    public string stageName;

    public float hpRatio; // ü�¹���
    public float rewardRatio; //�������

    public List<GameObject> mapPrefabs;
    public List<GameObject> enemyPrefabs;
}
