using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "StageData")]
public class StageDataSo : ScriptableObject
{
    public int stageID;
    public string stageName;

    public float hpRatio; // 체력배율
    public float rewardRatio; //보상배율

    public List<GameObject> mapPrefabs;
    public List<GameObject> enemyPrefabs;
}
