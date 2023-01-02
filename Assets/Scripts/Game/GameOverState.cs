using System.Collections.Generic;
using Effects;
using Unity.Services.Analytics;
using UnityEngine;

namespace Game
{
    public class GameOverState : IGameState
    {
        
        private readonly GameStateMachine _gameStateMachine;
        private readonly EffectManager _effectManager;
        private float _waitTimeSeconds;
        private bool _triggered;
        private GameSession _gameSession;

        public GameOverState(GameStateMachine gameStateMachine, EffectManager effectManager, GameSession gameSession)
        {
            _gameStateMachine = gameStateMachine;
            _effectManager = effectManager;
            _gameSession = gameSession;
        }

        public void Start()
        {
            _triggered = false;
            _waitTimeSeconds = 3.0f;
            _effectManager.PlayDieEffect();
            
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "level", _gameSession.Level }
            };
            
            AnalyticsService.Instance.CustomData("playerDeadLevel", parameters); 
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
            
        }
    }
}