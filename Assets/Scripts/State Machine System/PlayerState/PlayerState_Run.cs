using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Date/StateMachine/PlayerState/Run", fileName = "PlayerState_Run")]
public class PlayerState_Run : PlayerState
{
    public override void Enter()
    {
        animator.Play("Run");
    }

    public override void LogicUpdate()
    {
        if (!input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        if(input.StopRun)
        {
            stateMachine.SwitchState(typeof(PlayerState_Walk));
        }
    }
}
