using CollisionDetection;
using Effects;
using UnityEngine;
using Util;

namespace Player
{
    public class FirstFallingState : FallingState
    {
        public FirstFallingState(IPlayerCollisionDetection playerCollisionDetection, GameObject player, 
            IPlayerStateMachine playerStateMachine, float gravity, int deathY, EffectManager effectManager) 
            : base(playerCollisionDetection, player, playerStateMachine, gravity, deathY, effectManager)
        {
        }

        public override void Update()
        {
            
            if (!FallingInProgress)
            {
                return;
            }

            if (InputUtil.JumpStarted())
            {
                PlayerStateMachine.TransitionTo(PlayerStateId.SecondJumping);
                FallingInProgress = false;
            }
        }
    }
}