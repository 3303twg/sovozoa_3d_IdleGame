using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : IState
{
    private readonly CharacterFSM owner;
    public bool isAttack = false;

    public bool stopAttackFlag = false;
    float tempTime;
    public PlayerAttackState(CharacterFSM owner)
    {
        this.owner = owner;
        
    }

    public void Enter()
    {
        EventBus.Subscribe("PlayerHitAttackEvent", HitAttack);
        EventBus.Subscribe("PlayerEndAttackEvent", EndAttack);
        EventBus.Subscribe("KillEnemyEvent", StopAttack);
    }
    public void Exit()
    {
        EventBus.Unsubscribe("PlayerHitAttackEvent", HitAttack);
        EventBus.Unsubscribe("PlayerEndAttackEvent", EndAttack);
        EventBus.Unsubscribe("KillEnemyEvent", StopAttack);
    }

    public void StopAttack(object obj)
    {
        stopAttackFlag = true;
        //����� ������ ���¸ӽ� ����
    }
    public void Update()
    {
        //owner.playerController.stat.attackSpeed
        //�������� �ƴҶ���
        if (isAttack == false)
        {   
            if (stopAttackFlag == true)
            {
                owner.stateMachine.ChangeState(new PlayerIdleState(owner));
                return;
            }
            Debug.Log("�Ϳ�");
            isAttack = true;
            //���ݼӵ�
            owner.playerController.animator.speed = owner.playerController.animator.speed * owner.playerController.stat.attackSpeed;
            owner.playerController.animator.SetBool(owner.playerController.playerAnimationData.AttackParameterHash, true);


        }
    }
    //�ʺ�� hasExitTime �����ϴµ� ������ �̽����� �� �ߴ��� ������ ���Ӱ���
    public void HitAttack(object obj)
    {
        EventBus.Publish("EnemyHitEvent", owner.playerController.stat.attackPower);

        owner.playerController.animator.SetBool(owner.playerController.playerAnimationData.AttackParameterHash, false);

    }

    public void EndAttack(object obj)
    {
        Debug.Log("ȣ��");
        
        isAttack = false;
        owner.playerController.animator.speed = 1f;
    }
    
}
