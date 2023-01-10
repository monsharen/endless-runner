using UnityEngine;

namespace Util
{
    public class InputUtil
    {
        public static bool JumpStarted()
        {
            return Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump");
        }
        
        public static bool JumpEnded()
        {
            return Input.GetMouseButtonUp(0) || Input.GetButtonUp("Jump");
        }
    }
}