using UnityEngine;
using UnityEngine.UIElements;

namespace Player
{
    public class SecondJumpState : JumpState
    {

        public SecondJumpState(PlayerStateMachine playerStateMachine, GameObject player, float velocity, float gravity) : base(playerStateMachine, player, velocity, gravity)
        {
        }

        public override void Update()
        {
            if (!JumpingInProgress)
            {
                return;
            }
            
            if (Input.GetKeyUp("space") || Velocity < 0)
            {
                PlayerStateMachine.TransitionTo(PlayerStateId.SecondFalling);
                JumpingInProgress = false;
            }
        }
    }
}