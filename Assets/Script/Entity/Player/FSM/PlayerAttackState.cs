using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : IState
{
    private readonly CharacterFSM owner;

    public PlayerAttackState(CharacterFSM owner)
    {
        this.owner = owner;
    }

    public void Enter()
    {
        Debug.Log("╬Небе╘");
    }

    public void Exit()
    {
        
    }

    public void Update()
    {
        
    }
}
