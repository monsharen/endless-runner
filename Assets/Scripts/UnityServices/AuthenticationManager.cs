
using System.Threading.Tasks;
using Unity.Services.Analytics;
using Unity.Services.Authentication;
using UnityEngine;

namespace UnityServices
{
    public static class AuthenticationManager
    {
        public static IAuthentication Instance { get; private set; } = new NotLoggedInImpl();
        public static async Task Start()
        {
            try
            {
                await SignInAnonymously();
                
            }
            catch (ConsentCheckException e)
            {
                Debug.LogError("failed to initialize auth: " + e.Reason);
                Debug.LogException(e);
            }
        }
        
        private static async Task SignInAnonymously()
        {
            AuthenticationService.Instance.SignedIn += () =>
            {
                Debug.Log($"Signed in as: {AuthenticationService.Instance.PlayerId}, " +
                          $"{AuthenticationService.Instance.PlayerInfo.Id}");
                Instance = new LoggedInImpl(AuthenticationService.Instance.PlayerId);
            };
            AuthenticationService.Instance.SignInFailed += s =>
            {
                Debug.Log("failed to log in: " + s);
                Instance = new NotLoggedInImpl();
            };
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }

    }
    
    public interface IAuthentication
    {
        bool IsLoggedIn();
        string GetPlayerId();
    }

    class NotLoggedInImpl : IAuthentication
    {
        public bool IsLoggedIn()
        {
            return false;
        }

        public string GetPlayerId()
        {
            throw new System.NotImplementedException();
        }
    }

    class LoggedInImpl : IAuthentication
    {

        private string _playerId;

        public LoggedInImpl(string playerId)
        {
            this._playerId = playerId;
        }

        public bool IsLoggedIn()
        {
            return true;
        }

        public string GetPlayerId()
        {
            return _playerId;
        }
    }
}