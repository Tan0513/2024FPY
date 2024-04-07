using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Date/StateMachine/PlayerState/Walk", fileName = "PlayerState_Walk")]
public class PlayerState_Walk : PlayerState
{
    [SerializeField] float walkSpeed = 50f;
    public override void Enter()
    {
        animator.Play("Walk");
    }

    public override void LogicUpdate()
    {
        if (!input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        if(input.Run)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }
    }

    public override void PhysicUpdate()
    {
        Debug.Log(input.moveInput);
        //player.SetVelocity(walkSpeed);
    }
}
