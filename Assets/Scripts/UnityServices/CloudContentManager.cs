using System.Collections.Generic;
using UnityEngine;

namespace UnityServices
{
    public class CloudContentManager
    {

        public static Dictionary<string, string> GetUserNamesDictionary()
        {
            return new Dictionary<string, string>();
        }

        public static void UpdateUserName(string playerName)
        {

            if (playerName == null || playerName.Length < 1)
            {
                Debug.Log("invalid player name");
                return;
            }
            
            if (!AuthenticationManager.Instance.IsLoggedIn())
            {
                Debug.Log("not logged in. aborting");
                return;
            }

            var playerId = AuthenticationManager.Instance.GetPlayerId();
            
            Debug.Log($"updating name for player id '{playerId}' to '{playerName}'");
        }
    }
}