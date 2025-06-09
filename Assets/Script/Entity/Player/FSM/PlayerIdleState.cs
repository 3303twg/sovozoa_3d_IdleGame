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
        //에네미에게 타겟 달라고 이벤트 호출
        EventBus.Publish("TargetRequestEvent", owner.playerController.characterFSM);
    }

    public void Update()
    {
        //흠 좀 별로같은데
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
