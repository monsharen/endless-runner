using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class FirstJumpState : JumpState
    {

        
        public FirstJumpState(PlayerStateMachine playerStateMachine, GameObject player, float velocity, float gravity) : base(playerStateMachine, player, velocity, gravity)
        {
        }

        public override void Update()
        {
            if (!JumpingInProgress)
            {
                return;
            }
            
            if (Input.GetButtonUp("Jump") || Velocity < 0)
            {
                PlayerStateMachine.TransitionTo(PlayerStateId.FirstFalling);
                JumpingInProgress = false;
            }
        }
    }
}