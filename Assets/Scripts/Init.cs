using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityServices;

public class Init : MonoBehaviour
{
    async void Start()
    {
        await Unity.Services.Core.UnityServices.InitializeAsync();
        await AuthenticationManager.Start();
        await AnalyticsManager.Start();
        await LeaderboardsManager.Start();
        var highscores = await LeaderboardsManager.Instance.GetTop10();
        Debug.Log(JsonConvert.SerializeObject(highscores));
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
}
