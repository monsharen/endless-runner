using CollisionDetection;
using Effects;
using UnityEngine;

namespace Player
{
    public class SecondFallingState : FallingState
    {
        public SecondFallingState(IPlayerCollisionDetection playerCollisionDetection, GameObject player, 
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

            if (Input.GetButtonDown("Jump"))
            {
                PlayerStateMachine.TransitionTo(PlayerStateId.DashDown);
            }
        }
    }
}