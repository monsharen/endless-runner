using Game;
using UnityEngine;

namespace Player
{
    public abstract class JumpState : IPlayerState
    {
        private readonly GameObject _player;
        protected readonly PlayerStateMachine PlayerStateMachine;
        private readonly float _startVelocity;
        private readonly float _gravity;
        protected bool JumpingInProgress;
        private GameSession _gameSession;

        protected float Velocity;

        protected JumpState(GameSession gameSession, PlayerStateMachine playerStateMachine, GameObject player, float velocity, float gravity)
        {
            _gameSession = gameSession;
            PlayerStateMachine = playerStateMachine;
            _player = player;

            _gravity = gravity;
            _startVelocity = velocity;
        }

        public void Start()
        {
            _gameSession.CountJump();
            JumpingInProgress = true;
            Velocity = _startVelocity;
        }

        public abstract void Update();

        public void FixedUpdate()
        {
            var transformPosition = _player.transform.position;
            transformPosition.y += Velocity * Time.fixedDeltaTime;
            Velocity += _gravity * Time.fixedDeltaTime;
            _player.transform.position = transformPosition;
        }

        public void End()
        {
            JumpingInProgress = false;
        }
    }
}