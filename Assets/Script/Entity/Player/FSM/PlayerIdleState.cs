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
        EventBus.Subscribe("testTarget", GetTarget);
    }

    public void Update()
    {
        
        if(owner.target != null)
        {
            owner.stateMachine.ChangeState(new PlayerMoveState(owner));
        }
    }

    public void Exit()
    {
        EventBus.Unsubscribe("testTarget", GetTarget);
    }

    public void GetTarget(object obj)
    {
        GameObject go = obj as GameObject;

        owner.target = go.transform;
    }
}
