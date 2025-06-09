using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : IState
{
    private readonly CharacterFSM owner;
    public bool isAttack = false;

    float tempTime;
    public PlayerAttackState(CharacterFSM owner)
    {
        this.owner = owner;
        //owner.playerController.animator.SetBool(owner.playerController.playerAnimationData.AttackParameterHash, true);
    }

    public void Enter()
    {
        Debug.Log("어태크");
        EventBus.Subscribe("PlayerEndAttackEvent", EndAttack);
    }

    public void Exit()
    {
        EventBus.Unsubscribe("PlayerEndAttackEvent", EndAttack);
        //owner.playerController.animator.SetBool(owner.playerController.playerAnimationData.AttackParameterHash, false);
    }

    public void Update()
    {
        //owner.playerController.stat.attackSpeed
        //공격중이 아닐때만
        if (isAttack == false)
        {   //공격속도

                isAttack = true;
                owner.playerController.animator.speed = owner.playerController.animator.speed * owner.playerController.stat.attackSpeed;
                owner.playerController.animator.SetTrigger(owner.playerController.playerAnimationData.AttackParameterHash);

        }
        //무슨조건주지
        if (false)
        {
            owner.stateMachine.ChangeState(new PlayerIdleState(owner));
        }
    }

    public void EndAttack(object obj)
    {
        isAttack = false;
        EventBus.Publish("EnemyHitEvent", owner.playerController.stat.attackPower);
        owner.playerController.animator.speed = 1f;
    }
    
}
