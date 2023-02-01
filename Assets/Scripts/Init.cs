using UnityEngine;
using UnityServices;
using Util;

public class Init : MonoBehaviour
{
    async void Start()
    {
        await UnityServicesManager.Initialise();
        Scenes.ChangeScene(SceneId.Leaderboard);
    }
}
