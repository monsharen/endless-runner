using CollisionDetection;
using Effects;
using Game;
using UnityEngine;

namespace Player
{
    public class DashDownState : FallingState
    {

        private GameSession _gameSession;
        public DashDownState(
            GameSession gameSession,
            IPlayerCollisionDetection playerCollisionDetection, GameObject player, 
            IPlayerStateMachine playerStateMachine, float gravity, int deathY, EffectManager effectManager) 
            : base(playerCollisionDetection, player, playerStateMachine, gravity, deathY, effectManager)
        {
            _gameSession = gameSession;
        }

        public override void Start()
        {
            _gameSession.CountDashDown();
            base.Start();
            _velocity = _gravity;
        }
        public override void FixedUpdate()
        {
            if (!FallingInProgress)
            {
                return;
            }
            
            var transformPosition = _player.transform.position;
            transformPosition.y += _velocity * Time.fixedDeltaTime;
            //_velocity += _gravity * Time.fixedDeltaTime;
            _player.transform.position = transformPosition;
            
            if (_playerCollisionDetection.IsGrounded(transformPosition, _playerYLastFrame))
            {
                _effectManager.PlayDashDownLandingEffect();
                PlayerStateMachine.TransitionTo(PlayerStateId.Grounded);
                return;
            }

            var playerY = UnitConverter.EngineYToLevelY(transformPosition.y);
            
            if (playerY <= _deathY)
            {
                PlayerStateMachine.TransitionTo(PlayerStateId.Dead);
                return;
            }

            _playerYLastFrame = playerY;
        }
    }
}
