using Game;

namespace Player
{
    public class DeadState : IPlayerState
    {

        private GameStateMachine _gameStateMachine;

        public DeadState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            _gameStateMachine.TransitionTo(GameStateId.GameOver);
        }

        public void FixedUpdate()
        {
            
        }

        public void End()
        {
            
        }
    }
}