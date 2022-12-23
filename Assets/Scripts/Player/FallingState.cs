using CollisionDetection;
using Effects;
using UnityEngine;

namespace Player
{
    public abstract class FallingState : IPlayerState
    {
        protected readonly IPlayerCollisionDetection _playerCollisionDetection;
        protected readonly GameObject _player;
        protected readonly IPlayerStateMachine PlayerStateMachine;
        protected readonly float _gravity;
        protected readonly int _deathY;
        protected bool FallingInProgress = true; // Default to true for easy unit testing

        protected float _velocity = 0f;
        protected int _playerYLastFrame;
        protected EffectManager _effectManager;

        protected FallingState(IPlayerCollisionDetection playerCollisionDetection, GameObject player, 
            IPlayerStateMachine playerStateMachine, float gravity, int deathY, EffectManager effectManager)
        {
            _playerCollisionDetection = playerCollisionDetection;
            _player = player;
            PlayerStateMachine = playerStateMachine;
            _gravity = gravity;
            _deathY = deathY;
            _effectManager = effectManager;
        }

        public virtual void Start()
        {
            FallingInProgress = true;
            _velocity = 0f;
            _playerYLastFrame = UnitConverter.EngineYToLevelY(_player.transform.position.y);
        }

        public virtual void Update()
        {
            
        }

        public virtual void FixedUpdate()
        {
            if (!FallingInProgress)
            {
                return;
            }
            
            var transformPosition = _player.transform.position;
            transformPosition.y += _velocity * Time.fixedDeltaTime;
            _velocity += _gravity * Time.fixedDeltaTime;
            _player.transform.position = transformPosition;
            
            if (_playerCollisionDetection.IsGrounded(transformPosition, _playerYLastFrame))
            {
                _effectManager.PlayLandingEffect();
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

        public virtual void End()
        {
            FallingInProgress = false;
        }
    }
}