using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> mapPrefabs;
    public List<GameObject> enemyPrefabs;

    public StageDataSo stageDataSo;

    private void Awake()
    {
        CreateNextRoom(null);
    }
    private void OnEnable()
    {
        EventBus.Subscribe("CreateRoomEvent", CreateNextRoom);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe("CreateRoomEvent", CreateNextRoom);
    }
    public void CreateNextRoom(object obj)
    {
        //스테이지 정보 가져오기
        stageDataSo = StageDataBox.Instance.stageDataSo;
        mapPrefabs = stageDataSo.mapPrefabs;
        enemyPrefabs = stageDataSo.enemyPrefabs;


        Vector3 spawnPos = Camera.main.transform.position + Camera.main.transform.forward * 25f;
        spawnPos.x = 0f;
        spawnPos.y = 0f;

        
        GameObject mapObj = Instantiate(mapPrefabs[Random.Range(0, mapPrefabs.Count)], spawnPos, Quaternion.identity);


        

        GameObject go = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], spawnPos, Quaternion.identity, mapObj.transform);
        //이정도면 적당하더라
        go.transform.localPosition = new Vector3(-0.5f, 1.6f, 9f);

        go.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));

    }
}
