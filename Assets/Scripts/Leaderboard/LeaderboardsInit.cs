using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityServices;

namespace Leaderboard
{
    public class LeaderboardsInit : MonoBehaviour
    {
        
        public GameObject LeaderBoardNode;
        public List<TextMeshProUGUI> leaderboardNames = new List<TextMeshProUGUI>();
        public List<TextMeshProUGUI> leaderboardScores = new List<TextMeshProUGUI>();
        async void Start()
        {
            LeaderBoardNode.SetActive(false);
            
            if (!UnityServicesManager.Initialised())
            {
                await UnityServicesManager.Initialise();
            }
        
            LeaderboardsManager.Start();

            var highscores = await LeaderboardsManager.Instance.GetTop10();
            Debug.Log(JsonConvert.SerializeObject(highscores));
            
            
        
            UpdateText(highscores);
            
            LeaderBoardNode.SetActive(true);
        }

        private void UpdateText(List<Highscore> highscores)
        {
            for (int i = 0; i < leaderboardNames.Count; i++)
            {
                string name = "";
                string score = "";
                if (i < highscores.Count)
                {
                    var highscore = highscores[i];
                    name = highscore.PlayerName;
                    score = "" + highscore.Score;
                }
            
                leaderboardNames[i].text = name;
                leaderboardScores[i].text = score;
            }
        }
    }
}
