using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class CharacterFSM : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 3f;

    public StateMachine stateMachine;

    void Start()
    {
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new PlayerIdleState(this));
    }

    void Update()
    {
        stateMachine.Update();
    }
}
