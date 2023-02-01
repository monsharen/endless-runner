using UnityEngine;
using Util;

namespace Leaderboard
{
    public class LeaderboardButton : MonoBehaviour
    {

        public void StartGameButton()
        {
            Scenes.ChangeScene(SceneId.Level);
        }
    }
}