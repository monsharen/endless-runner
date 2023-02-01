using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Analytics;
using Unity.Services.Leaderboards;
using UnityEngine;

namespace UnityServices
{
    public class LeaderboardsManager
    {
        public static ILeaderboard Instance { get; private set; } = new EmptyLeaderboard();
        public static void Start()
        {
            try
            {
                if (AuthenticationManager.Instance.IsLoggedIn())
                {
                    Instance = new LeaderboardImpl();
                }

            }
            catch (ConsentCheckException e)
            {
                Debug.LogError("failed to initialize analytics: " + e.Reason);
                Debug.LogException(e);
            }
        }
    }
    
    public interface ILeaderboard
    {
        void AddScore(int i);

        Task<List<Highscore>> GetTop10();
    }

    class EmptyLeaderboard : ILeaderboard
    {
        public void AddScore(int i)
        {
            Debug.Log("ignoring score as user not logged in");
        }

        public Task<List<Highscore>> GetTop10()
        {
            return Task.FromResult(new List<Highscore>());
        }
    }

    class LeaderboardImpl : ILeaderboard
    {

        private const string LeaderboardId = "longest-run";
        
        public async void AddScore(int i)
        {
            await LeaderboardsService.Instance
                .LeaderboardsApi.AddLeaderboardPlayerScoreAsync(LeaderboardId, i);
        }

        public async Task<List<Highscore>> GetTop10()
        {
            var offset = 0;
            var limit = 10;
            var scoresResponse = await LeaderboardsService.Instance
                .LeaderboardsApi.GetLeaderboardScoresAsync(LeaderboardId, offset, limit);
            var scoresResponseResults = scoresResponse.Results;
            var highscores = new List<Highscore>();
            foreach (var entry in scoresResponseResults)
            {
                highscores.Add(new Highscore(entry.PlayerId, (int) entry.Score));
            }
            return highscores;
        }
    }

    public class Highscore
    {
        public string PlayerName { get;  }
        public int Score { get; }

        public Highscore(string playerName, int score)
        {
            PlayerName = playerName;
            Score = score;
        }
    }
}