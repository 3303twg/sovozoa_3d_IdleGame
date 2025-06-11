using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public PlayerAnimationData playerAnimationData;

    public Animator animator;

    [SerializeField]
    public PlayerStat stat;

    [SerializeField]
    public CharacterFSM characterFSM;


    private void OnEnable()
    {
        EventBus.Subscribe("AddItemStatEvent", AddStat);
        EventBus.Subscribe("ReduceItemStatEvent", ReduceStat);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe("AddItemStatEvent", AddStat);
        EventBus.Unsubscribe("ReduceItemStatEvent", ReduceStat);
    }

    //아이템 착용시 스탯 상승 갱신
    public void AddStat(object obj)
    {
        ItemData data = (ItemData)obj;
        stat.attackPower += data.attackPower;
        stat.attackSpeed += data.attackSpeed;
        stat.criticalChance += data.criticalChance;
        stat.criticalRatio += data.criticalRatio;
        stat.accuracy += data.accuracy;
    }

    //아이템 착용 해제시 스탯 하락 갱신
    public void ReduceStat(object obj)
    {
        ItemData data = (ItemData)obj;
        stat.attackPower -= data.attackPower;
        stat.attackSpeed -= data.attackSpeed;
        stat.criticalChance -= data.criticalChance;
        stat.criticalRatio -= data.criticalRatio;
        stat.accuracy -= data.accuracy;
    }


    private void Awake()
    {
        playerAnimationData.InitAnimationHash();
        animator = GetComponent<Animator>();
        characterFSM = GetComponent<CharacterFSM>();
    }

    //애니메이션중 공격을 맞추는타이밍때 호출
    public void HitAttack()
    {
        EventBus.Publish("PlayerHitAttackEvent", null);
    }

    //애니메이션중 공격이 종료될경우 호출
    public void EndAttack()
    {
        EventBus.Publish("PlayerEndAttackEvent", null);
    }


}
