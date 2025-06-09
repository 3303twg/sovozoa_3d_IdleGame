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
