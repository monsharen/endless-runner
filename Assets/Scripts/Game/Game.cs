using Effects;
using UnityEngine;

namespace Game
{
    public class Game : MonoBehaviour
    {

        public GameObject platformParentNode;
        public GameObject platformPrefab;
        public GameObject playerYGameObject;
        public GameObject playerXGameObject;
        public ParticleSystem landParticleSystem;
        public float gravity;
        public float jumpVelocity;
        public int deathY;

        private GameStateMachine _gameStateMachine;

        private void Start()
        {
            var gameSession = new GameSession(1);

            var levelRenderer = new LevelRenderer(platformPrefab, platformParentNode);
            var effectManager = new EffectManager(landParticleSystem, Camera.main.gameObject, this);

            _gameStateMachine = new GameStateMachine();
            _gameStateMachine.GameStates.Add(GameStateId.Dead, new EmptyState());
            _gameStateMachine.GameStates.Add(GameStateId.Paused, new EmptyState());
            _gameStateMachine.GameStates.Add(GameStateId.GameOver, new GameOverState(
                _gameStateMachine, effectManager, gameSession));
            _gameStateMachine.GameStates.Add(GameStateId.Playing, 
                new PlayingState(
                    _gameStateMachine, 
                    levelRenderer, 
                    playerXGameObject, 
                    playerYGameObject, 
                    gravity, 
                    jumpVelocity, 
                    deathY,
                    effectManager,
                    gameSession));
            _gameStateMachine.GameStates.Add(GameStateId.StartNewGame, new StartNewGameState(
                _gameStateMachine, gameSession));
            _gameStateMachine.TransitionTo(GameStateId.StartNewGame);
        }

        private void Update()
        {
            _gameStateMachine.Update();
        }

        private void FixedUpdate()
        {
            _gameStateMachine.FixedUpdate();
        }

        private void OnDestroy()
        {
            _gameStateMachine.End();
        }
    }
}