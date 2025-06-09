using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject RoomPrefab;
    public GameObject EnemyPrefab;
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
        Vector3 spawnPos = Camera.main.transform.position + Camera.main.transform.forward * 25f;
        spawnPos.x = 0f;
        spawnPos.y = 0f;
        GameObject mapObj = Instantiate(RoomPrefab, spawnPos, Quaternion.identity);


        

        GameObject go = Instantiate(EnemyPrefab, spawnPos, Quaternion.identity, mapObj.transform);
        //이정도면 적당하더라
        go.transform.localPosition = new Vector3(-0.5f, 1.6f, 9f);

    }
}
