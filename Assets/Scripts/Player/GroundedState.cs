using Effects;
using UnityEngine;

namespace Player
{
    public class GroundedState : IPlayerState
    {

        private readonly PlayerStateMachine _playerStateMachine;
        private readonly Level _level;
        private readonly GameObject _player;
        private readonly EffectManager _effectManager;
        
        public GroundedState(PlayerStateMachine playerStateMachine, Level level, GameObject player, 
            EffectManager effectManager)
        {
            _playerStateMachine = playerStateMachine;
            _level = level;
            _player = player;
            _effectManager = effectManager;
        }

        public void Start()
        {
            var position = _player.transform.position;
            var playerX = UnitConverter.EngineXToLevelX(position.x);
            var heightAt = _level.GetHeightAt(playerX);
            _player.transform.position = new Vector2(position.x, heightAt);
        }

        public void Update()
        {
            var playerX = UnitConverter.EngineXToLevelX(_player.transform.position.x);
            var heightAt = _level.GetHeightAt(playerX);

            if (heightAt < 0)
            {
                _playerStateMachine.TransitionTo(PlayerStateId.FirstFalling);
                return;
            }

            var playerY = UnitConverter.EngineYToLevelY(_player.transform.position.y);

            if (playerY < heightAt)
            {
                _playerStateMachine.TransitionTo(PlayerStateId.FirstFalling);
                return;
            }

            if (Input.GetKeyDown("space"))
            {
                _effectManager.PlayLandingEffect();
                _playerStateMachine.TransitionTo(PlayerStateId.FirstJumping);
                return;
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