using UnityEngine;

namespace Game
{
    public class StartNewGameState : IGameState
    {

        private GameStateMachine _gameStateMachine;
        private GameSession _gameSession;

        public StartNewGameState(GameStateMachine gameStateMachine, GameSession gameSession)
        {
            _gameStateMachine = gameStateMachine;
            _gameSession = gameSession;
        }

        public void Start()
        {
            _gameSession.StartNewSession();
        }

        public void Update()
        {
            _gameStateMachine.TransitionTo(GameStateId.Playing);
        }

        public void FixedUpdate()
        {
            
        }

        public void End()
        {
                   
        }
    }
}