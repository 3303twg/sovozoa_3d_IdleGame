using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyDataSo enemyDataSo;
    public EnemyStat enemyStat;

    public bool isDie;

    private void Awake()
    {
        enemyStat = new EnemyStat(enemyDataSo);
        
    }


    private void OnEnable()
    {
        EventBus.Subscribe("EnemyHitEvent", RefrashHP);
        EventBus.Subscribe("TargetRequestEvent", SetTarget);
    }
    private void OnDisable()
    {
        EventBus.Unsubscribe("EnemyHitEvent", RefrashHP);
        EventBus.Unsubscribe("TargetRequestEvent", SetTarget);

    }

    void Start()
    {
        EventBus.Publish("EnemyInitEvent", enemyDataSo);
        
        UIManager.Instance.ShowUI("EnemyUI");
    }

    private void Update()
    {
        
    }

    public void SetTarget(object obj)
    {
        CharacterFSM fsm = (CharacterFSM)obj;
        fsm.target = gameObject.transform;
    }
    public void RefrashHP(object obj)
    {
        enemyStat.curHp -= (float)obj;
        EventBus.Publish("RefrashHPEvent", enemyStat.curHp / enemyStat.maxHp);
        if (enemyStat.curHp <= 0)
        {
            isDie = true;
            EventBus.Publish("KillEnemyEvent", null);
            UIManager.Instance.HideUI("EnemyUI");

            //일단 적이 죽을때 다음 스테이지 생성
            EventBus.Publish("CreateRoomEvent", null);

            foreach (var item in enemyDataSo.dropTable.item)
            {
                Instantiate(item.itemPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            
        }
    }
}
