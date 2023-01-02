using UnityEngine;

namespace CollisionDetection
{
    public class PlayerCollisionDetection : IPlayerCollisionDetection
    {

        private readonly Level.Level _level;

        public PlayerCollisionDetection(Level.Level level)
        {
            _level = level;
        }

        public bool IsGrounded(Vector3 transformPosition, int playerYLastFrame)
        {
            // Ground is not negative this frame
            // Above ground previous frame and Under Ground this frame
            var playerX = UnitConverter.EngineXToLevelX(transformPosition.x);
            var clampedPlayerX = Mathf.Clamp(playerX, 0, _level.GetLength());
            
            var levelHeightThisFrame = _level.GetHeightAt(clampedPlayerX);

            if (levelHeightThisFrame < 0) // Can't be grounded. Platform does not exist here
            {
                return false;
            }
            
            var playerYThisFrame = UnitConverter.EngineYToLevelY(transformPosition.y);
            
            if (playerYThisFrame > levelHeightThisFrame) // We're above ground. Not yet grounded
            {
                return false;
            } 
            
            if (playerYThisFrame == levelHeightThisFrame) // We're equal to ground. Grounded
            {
                return true;
            }

            // We were above last frame, and underneath this frame. Did we miss the platform legitimately?
            // If there is still ground, then do benefit of doubt and say grounded

            bool playerWereAbovePlatformLastFrame = playerYLastFrame > levelHeightThisFrame;
            bool playerIsUnderneathThisFrame = playerYThisFrame < levelHeightThisFrame;
            bool isGrounded = playerWereAbovePlatformLastFrame && playerIsUnderneathThisFrame;
            
            return isGrounded;
        }
    }
}
