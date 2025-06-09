using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{

    public int MoveParameterHash;
    public int AttackParameterHash;
    //public int AttackParameterHash;

    public void InitAnimationHash()
    {
        MoveParameterHash = Animator.StringToHash("isMove");
        AttackParameterHash = Animator.StringToHash("isAttack");

    }
}
