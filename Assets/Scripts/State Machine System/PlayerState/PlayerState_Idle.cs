using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Date/StateMachine/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle : PlayerState
{
    public override void Enter()
    {
        animator.Play("Idle");
    }

    public override void LogicUpdate()
    {
        if (input.Run)
        {
            if(input.Move)
            {
                stateMachine.SwitchState(typeof(PlayerState_Walk));
            }
            else
            {
                stateMachine.SwitchState(typeof(PlayerState_Run));
            }
        }

        if (input.Move)
        {
            if(input.Run)
            {
                stateMachine.SwitchState(typeof(PlayerState_Run));
            }
            else
            {
                stateMachine.SwitchState(typeof(PlayerState_Walk));
            }
        }
    }

    public override void PhysicUpdate()
    {
        // player.CamControll();
    }
}
