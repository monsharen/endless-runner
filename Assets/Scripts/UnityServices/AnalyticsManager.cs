using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Analytics;
using UnityEngine;

namespace UnityServices
{
    public static class AnalyticsManager
    {

        public static IAnalytics Instance { get; private set; } = new EmptyAnalytics();
        public static async Task Start()
        {
            try
            {
                await Unity.Services.Core.UnityServices.InitializeAsync();
                List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();

                Instance = new AnalyticsImpl();
            }
            catch (ConsentCheckException e)
            {
                Debug.LogError("failed to initialize analytics: " + e.Reason);
                Debug.LogException(e);
            }
        }
    }

    public interface IAnalytics
    {
        public void SendPlayerDiedAtLevelEvent(int level);
    }

    class EmptyAnalytics : IAnalytics
    {
        public void SendPlayerDiedAtLevelEvent(int level)
        {
        }
    }

    class AnalyticsImpl : IAnalytics
    {
        public void SendPlayerDiedAtLevelEvent(int level)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "level", level }
            };
            
            AnalyticsService.Instance.CustomData("playerDeadLevel", parameters); 
        }
    }
}
