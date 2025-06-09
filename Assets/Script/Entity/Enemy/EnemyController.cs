using System.Collections;
using System.Collections.Generic;
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
    }
    private void OnDisable()
    {
        EventBus.Unsubscribe("EnemyHitEvent", RefrashHP);

    }

    void Start()
    {
        EventBus.Publish("EnemyInitEvent", enemyDataSo);
    }

    private void Update()
    {
        
    }

    public void test()
    {
        EventBus.Publish("testTarget", gameObject);
        UIManager.Instance.ShowUI("EnemyUI");
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

            foreach (var item in enemyDataSo.dropTable.item)
            {
                Instantiate(item.itemPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            
        }
    }
}
