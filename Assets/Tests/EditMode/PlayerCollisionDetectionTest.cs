using CollisionDetection;
using Level;
using NUnit.Framework;
using UnityEngine;

namespace Tests.EditMode
{
    public class PlayerCollisionDetectionTest
    {
        
        [Test]
        public void PlayerCollisionDetectionTestSimple()
        {
            Level.Level level = new Level.Level();
            level.Add(new Platform(0, 1));
            var playerCollisionDetection = new PlayerCollisionDetection(level);
            var isGrounded = playerCollisionDetection.IsGrounded(new Vector3(0, 0, 0), 0);
            Assert.IsTrue(isGrounded);
        }
        
        [Test]
        public void ShouldReturnTrueWhenPlayerWasAboveLastFrameAndNowIsBelow()
        {
            Level.Level level = new Level.Level();
            level.Add(new Platform(0, 1));
            var playerCollisionDetection = new PlayerCollisionDetection(level);
            var isGrounded = playerCollisionDetection.IsGrounded(new Vector3(0, -1, 0), 1);
            Assert.IsTrue(isGrounded);
        }

    }
}
