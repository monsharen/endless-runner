using CollisionDetection;
using Effects;
using Player;
using UnityEngine;

namespace Game
{
    public class PlayingState : IGameState
    {
        private const float InitialPlayerSpeed = 10f;
        private const float SpeedIncreasePerLevel = 1.5f;

        private readonly GameStateMachine _gameStateMachine;
        private PlayerStateMachine _playerStateMachine;
        private readonly LevelRenderer _levelRenderer;
        private readonly GameObject _player;
        private readonly GameObject _playerYGameObject;
        private readonly float _gravity;
        private readonly float _jumpVelocity;
        private readonly int _deathY;
        private Level.Level _level;
        private readonly EffectManager _effectManager;
        private readonly GameSession _gameSession;
        
        private float _currentPlayerSpeed = InitialPlayerSpeed;

        public PlayingState(GameStateMachine gameStateMachine, LevelRenderer levelRenderer, GameObject player, 
            GameObject playerYGameObject, float gravity, float jumpVelocity, int deathY,
            EffectManager effectManager, GameSession gameSession)
        {
            _gameStateMachine = gameStateMachine;
            _levelRenderer = levelRenderer;
            _player = player;
            _playerYGameObject = playerYGameObject;
            _gravity = gravity;
            _jumpVelocity = jumpVelocity;
            _deathY = deathY;
            _effectManager = effectManager;
            _gameSession = gameSession;
        }

        public void Start()
        {
            ResetLevel();
            
            _playerStateMachine.TransitionTo(PlayerStateId.Grounded);
        }

        public void Update()
        {
            _playerStateMachine.Update();
        }

        public void FixedUpdate()
        {
            var playerX = UnitConverter.EngineXToLevelX(_player.transform.position.x);

            if (playerX >= _level.GetLength())
            {
                GoToNextLevel();
                return;
            }
            MovePlayerX();
            _playerStateMachine.FixedUpdate();
        }

        public void End()
        {
            _playerStateMachine.End();
        }

        private void GoToNextLevel()
        {
            _currentPlayerSpeed *= SpeedIncreasePerLevel;
            _gameSession.NextLevel();
            _gameStateMachine.TransitionTo(GameStateId.Playing);
        }

        private void ResetLevel()
        {
            _player.transform.position = new Vector3();
            _level = LevelGenerator.Generate(4, 20, 4);
            _currentPlayerSpeed = InitialPlayerSpeed;
            
            var playerCollisionDetection = new PlayerCollisionDetection(_level);
            
            _playerStateMachine = new PlayerStateMachine();
            _playerStateMachine.PlayerStates.Add(PlayerStateId.Grounded, new GroundedState(
                _playerStateMachine, _level, _playerYGameObject, _effectManager, playerCollisionDetection));
            _playerStateMachine.PlayerStates.Add(PlayerStateId.FirstJumping, new FirstJumpState(
                _playerStateMachine, _playerYGameObject, _jumpVelocity, _gravity));
            _playerStateMachine.PlayerStates.Add(PlayerStateId.SecondJumping, new SecondJumpState(
                _playerStateMachine, _playerYGameObject, _jumpVelocity, _gravity));
            _playerStateMachine.PlayerStates.Add(PlayerStateId.FirstFalling, new FirstFallingState(
                playerCollisionDetection, _playerYGameObject, _playerStateMachine, _gravity, _deathY, _effectManager));
            _playerStateMachine.PlayerStates.Add(PlayerStateId.SecondFalling, new SecondFallingState(
                playerCollisionDetection, _playerYGameObject, _playerStateMachine, _gravity, _deathY, _effectManager));
            _playerStateMachine.PlayerStates.Add(PlayerStateId.Dead, new DeadState(
                _gameStateMachine));
            _playerStateMachine.PlayerStates.Add(PlayerStateId.FallingOffPlatform, new FallingOffPlatformState(
                playerCollisionDetection, _playerYGameObject, _playerStateMachine, _gravity, _deathY, _effectManager));
            _playerStateMachine.PlayerStates.Add(PlayerStateId.DashDown, new DashDownState(
                playerCollisionDetection, _playerYGameObject, _playerStateMachine, _gravity, _deathY, _effectManager));
            
            _levelRenderer.DestroyAll();
            _levelRenderer.Render(_level, 0);
        }
        
        private void MovePlayerX()
        {
            var transformPosition = _player.transform.position;
            transformPosition += Vector3.right * (Time.deltaTime * GetCurrentSpeed());
            _player.transform.position = transformPosition;
        }

        private float GetCurrentSpeed()
        {
            return _currentPlayerSpeed;
        }
    }
}