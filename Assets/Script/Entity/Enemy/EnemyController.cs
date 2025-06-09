using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyDataSo enemyDataSo;
    public EnemyStat enemyStat;


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

    public void test()
    {
        EventBus.Publish("testTarget", gameObject);
    }

    public void RefrashHP(object obj)
    {
        enemyStat.curHp -= (float)obj;
        EventBus.Publish("RefrashHPEvent", enemyStat.curHp / enemyStat.maxHp);
    }
}
