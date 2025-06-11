using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemyDataSo enemyDataSo;
    [SerializeField]
    public EnemyStat enemyStat;
    public GameObject cubePeacePrefab;
    public GameObject goldPrefab;
    public GameObject diamondPrefab;

    public bool isDie;

    private void Awake()
    {
        //스테이지와 진행카운트에 따라 배율 적용해줄듯?
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
        UIManager.Instance.ShowUI("EnemyUI");
        //이름 변경
        EventBus.Publish("EnemyInitEvent", enemyDataSo);
        //최대치
        EventBus.Publish("RefrashHPEvent", 1f);
        
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

            Instantiate(cubePeacePrefab, transform.position, Quaternion.identity);
            int rand = Random.Range(15, 70);
            int gold = Random.Range(enemyDataSo.dropTable.gold - (enemyDataSo.dropTable.gold / 10), enemyDataSo.dropTable.gold + (enemyDataSo.dropTable.gold / 10));
            for (int  i = 0; i < rand; i ++)
            {
                GameObject go = Instantiate(goldPrefab, transform.position, Quaternion.identity);
                go.GetComponent<Item>().value = gold / rand;
            }
            foreach (var item in enemyDataSo.dropTable.item)
            {
                
                Instantiate(item.itemPrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);

        }
    }
}
