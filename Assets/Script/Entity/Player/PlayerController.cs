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

    public void AddStat(object obj)
    {
        ItemData data = (ItemData)obj;
        stat.attackPower += data.attackPower;
        stat.attackSpeed += data.attackSpeed;
        stat.criticalChance += data.criticalChance;
        stat.criticalRatio += data.criticalRatio;
        stat.accuracy += data.accuracy;
    }

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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HitAttack()
    {
        EventBus.Publish("PlayerHitAttackEvent", null);
    }

    public void EndAttack()
    {
        EventBus.Publish("PlayerEndAttackEvent", null);
    }


}
