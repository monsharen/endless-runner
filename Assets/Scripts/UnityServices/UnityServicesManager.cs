using System.Threading.Tasks;
using Unity.Services.Core;

namespace UnityServices
{
    public class UnityServicesManager
    {

        public static async Task Initialise()
        {
            await Unity.Services.Core.UnityServices.InitializeAsync();
            await AuthenticationManager.Start();
            await AnalyticsManager.Start();
        }

        public static bool Initialised()
        {
            if (Unity.Services.Core.UnityServices.State != ServicesInitializationState.Initialized)
            {
                return false;
            } 
            
            if (!AuthenticationManager.Instance.IsLoggedIn())
            {
                return false;
            }
            
            return AnalyticsManager.Instance.Initialised();
        }
    }
}