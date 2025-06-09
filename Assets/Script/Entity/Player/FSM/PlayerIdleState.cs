using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerIdleState : IState
{
    private readonly CharacterFSM owner;

    public PlayerIdleState(CharacterFSM owner)
    {
        this.owner = owner;
    }

    public void Enter()
    {
        //���׹̿��� Ÿ�� �޶�� �̺�Ʈ ȣ��
        EventBus.Publish("TargetRequestEvent", owner.playerController.characterFSM);
    }

    public void Update()
    {
        //�� �� ���ΰ�����
        EventBus.Publish("TargetRequestEvent", owner.playerController.characterFSM);
        if (owner.target != null)
        {
            owner.stateMachine.ChangeState(new PlayerMoveState(owner));
        }
    }

    public void Exit()
    {
        //EventBus.Unsubscribe("TargetRequestEvent", GetTarget);
    }

    public void GetTarget(object obj)
    {
        GameObject go = obj as GameObject;

        owner.target = go.transform;
    }
}
