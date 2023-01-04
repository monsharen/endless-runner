using UnityEngine;
using UnityEngine.SceneManagement;
using UnityServices;

public class Init : MonoBehaviour
{
    async void Start()
    {
        await AnalyticsManager.Start();

        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
}
