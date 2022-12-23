using System;
using CollisionDetection;
using Effects;
using NSubstitute;
using NUnit.Framework;
using Player;
using UnityEngine;

namespace Tests.EditMode
{
    public class FallingStateTest
    {

        [Test]
        public void FallingStateTestSimplePasses()
        {
            var playerPosition = new Vector3(0, 0, 0);
            var player = GeneratePlayer(playerPosition);
            var playerCollisionDetection = Substitute.For<IPlayerCollisionDetection>();
            var playerStateMachine = Substitute.For<IPlayerStateMachine>();
            var effectManager = Substitute.For<EffectManager>();
            var firstFallingState = new FirstFallingState(
                playerCollisionDetection, player, playerStateMachine, 0, 
                Int16.MinValue, effectManager);
            playerCollisionDetection.IsGrounded(playerPosition, 0).Returns(true);
            // Act
            firstFallingState.FixedUpdate();
            
            // Assert
            playerStateMachine.Received().TransitionTo(PlayerStateId.Grounded);
        }

        private GameObject GeneratePlayer(Vector3 playerPosition)
        {
            var player = new GameObject();
            player.transform.position = playerPosition;
            return player;
        }
    }
    
    
}
