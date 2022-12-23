using UnityEngine;

namespace CollisionDetection
{
    public interface IPlayerCollisionDetection
    {
        public bool IsGrounded(Vector3 transformPosition, int playerYLastFrame);
    }
}