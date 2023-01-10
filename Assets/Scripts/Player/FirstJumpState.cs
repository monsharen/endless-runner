using Game;
using UnityEngine;
using Util;

namespace Player
{
    public class FirstJumpState : JumpState
    {

        public FirstJumpState(GameSession gameSession, PlayerStateMachine playerStateMachine, GameObject player, float velocity, float gravity) : base(gameSession, playerStateMachine, player, velocity, gravity)
        {
        }

        public override void Update()
        {
            if (!JumpingInProgress)
            {
                return;
            }
            
            if (InputUtil.JumpEnded() || Velocity < 0)
            {
                PlayerStateMachine.TransitionTo(PlayerStateId.FirstFalling);
                JumpingInProgress = false;
            }
        }
    }
}