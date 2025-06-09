using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

[Serializable]
public class CharacterFSM : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 3f;

    [SerializeField]
    public StateMachine stateMachine;
    public PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new PlayerIdleState(this));
    }

    void Update()
    {
        stateMachine.Update();
    }
}
