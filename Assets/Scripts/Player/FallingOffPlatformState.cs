using CollisionDetection;
using Effects;
using UnityEngine;

namespace Player
{
    public class FallingOffPlatformState : FallingState
    {
        public FallingOffPlatformState(IPlayerCollisionDetection playerCollisionDetection, GameObject player, IPlayerStateMachine playerStateMachine, float gravity, int deathY, EffectManager effectManager) : base(playerCollisionDetection, player, playerStateMachine, gravity, deathY, effectManager)
        {
        }
    }
}