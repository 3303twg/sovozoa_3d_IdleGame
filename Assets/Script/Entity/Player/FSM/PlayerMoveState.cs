
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveState : IState
{
    private readonly CharacterFSM owner;
    Vector3 targetPos;

    public float moveSpeed = 5f;
    public PlayerMoveState(CharacterFSM owner)
    {
        this.owner = owner;
    }
    public void Enter()
    {
        targetPos = owner.target.transform.position + owner.target.transform.forward * 1.5f;
        targetPos.y = 0f;
    }

    public void Exit()
    {
        //throw new System.NotImplementedException();
    }

    public void Update()
    {
        float distance = Vector3.Distance(owner.transform.position, targetPos);
        if (distance >= 0.1f)
        {
            Vector3 MoveDirection = (targetPos - owner.transform.position).normalized;

            owner.transform.position += MoveDirection * moveSpeed * Time.deltaTime;
        }
        else
        {
            owner.stateMachine.ChangeState(new PlayerAttackState(owner));
        }
    }
}
