using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int cnt = 0;

    private void OnEnable()
    {
        EventBus.Subscribe("CreateRoomEvent", AddCnt);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe("CreateRoomEvent", AddCnt);
    }

    public void AddCnt(object obj)
    {
        cnt++;
        if(cnt > 1)
        {
            Destroy(gameObject);
        }
    }
}
