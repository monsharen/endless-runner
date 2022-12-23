using UnityEngine;

namespace Game
{
    public class StartNewGameState : IGameState
    {

        private GameStateMachine _gameStateMachine;

        public StartNewGameState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Start()
        {
            //_level = LevelGenerator.Generate(8, 20, 4);
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
            Debug.Log("StartNewGameState going to next state");            
        }
    }
}