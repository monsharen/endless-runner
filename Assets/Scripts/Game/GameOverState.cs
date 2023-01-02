using Effects;
using UnityEngine;

namespace Game
{
    public class GameOverState : IGameState
    {
        
        private readonly GameStateMachine _gameStateMachine;
        private readonly EffectManager _effectManager;
        private float _waitTimeSeconds;
        private bool _triggered;

        public GameOverState(GameStateMachine gameStateMachine, EffectManager effectManager)
        {
            _gameStateMachine = gameStateMachine;
            _effectManager = effectManager;
        }

        public void Start()
        {
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
            
        }
    }
}