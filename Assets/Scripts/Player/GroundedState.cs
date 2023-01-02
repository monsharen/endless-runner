using CollisionDetection;
using Effects;
using UnityEngine;

namespace Player
{
    public class GroundedState : IPlayerState
    {

        private readonly PlayerStateMachine _playerStateMachine;
        private readonly Level.Level _level;
        private readonly GameObject _player;
        private readonly EffectManager _effectManager;
        private readonly PlayerCollisionDetection _playerCollisionDetection;
        private int _groundY = 0;
        
        public GroundedState(PlayerStateMachine playerStateMachine, Level.Level level, GameObject player, 
            EffectManager effectManager, PlayerCollisionDetection playerCollisionDetection)
        {
            _playerStateMachine = playerStateMachine;
            _level = level;
            _player = player;
            _effectManager = effectManager;
            _playerCollisionDetection = playerCollisionDetection;
        }

        public void Start()
        {
            MovePlayerToCurrentPlatformHeight();
        }

        public void FixedUpdate()
        {
            if (!_playerCollisionDetection.IsGrounded(_player.transform.position, _groundY))
            {
                _playerStateMachine.TransitionTo(PlayerStateId.FallingOffPlatform);
            }
        }

        public void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                _effectManager.PlayLandingEffect();
                _playerStateMachine.TransitionTo(PlayerStateId.FirstJumping);
            }
        }

        public void End()
        {
            
        }

        private void MovePlayerToCurrentPlatformHeight()
        {
            var position = _player.transform.position;
            var playerX = UnitConverter.EngineXToLevelX(position.x);
            var heightAt = _level.GetHeightAt(playerX);
            _groundY = heightAt;
            _player.transform.position = new Vector2(position.x, heightAt);
        }
    }
}