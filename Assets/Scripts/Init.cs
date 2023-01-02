using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync();
            List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();
            SceneManager.LoadScene("Level", LoadSceneMode.Single);
        }
        catch (ConsentCheckException e)
        {
            
        }
    }
}
