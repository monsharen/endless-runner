using Effects;
using UI;
using UnityEngine;
using UnityServices;
using Util;

namespace Game
{
    public class GameOverState : IGameState
    {
        
        private readonly GameStateMachine _gameStateMachine;
        private readonly EffectManager _effectManager;
        private float _waitTimeSeconds;
        private bool _triggered;
        private readonly GameSession _gameSession;
        private readonly UIManager _uiManager;

        public GameOverState(GameStateMachine gameStateMachine, EffectManager effectManager, GameSession gameSession, UIManager uiManager)
        {
            _gameStateMachine = gameStateMachine;
            _effectManager = effectManager;
            _gameSession = gameSession;
            _uiManager = uiManager;
        }

        public void Start()
        {
            _gameSession.CountDeath();
            AnalyticsManager.Instance.SendPlayerDiedAtLevelEvent(_gameSession.Level);
            if (AuthenticationManager.Instance.IsLoggedIn())
            {
                Debug.Log("adding highscore " + _gameSession.Level);
                LeaderboardsManager.Instance.AddScore(_gameSession.Level);
                Scenes.ChangeScene(SceneId.Leaderboard);
            }
            
            _triggered = false;
            _waitTimeSeconds = 3.0f;
            _effectManager.PlayDieEffect();
        }

        public void Update()
        {
            if (_triggered)
            {
                return;
            }
            
            _waitTimeSeconds -= Time.deltaTime;
            if (_waitTimeSeconds < 0)
            {
                _gameStateMachine.TransitionTo(GameStateId.StartNewGame);
                _triggered = true;
            }
        }

        public void FixedUpdate()
        {
            
        }

        public void End()
        {
            _uiManager.HideHighscore();
        }
    }
}