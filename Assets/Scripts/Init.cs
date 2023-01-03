using UnityEngine;
using UnityServices;

public class Init : MonoBehaviour
{
    async void Start()
    {
        await AnalyticsManager.Start();
    }
}
