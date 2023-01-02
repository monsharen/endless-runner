using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerStateMachine : IPlayerStateMachine
    {
        public readonly Dictionary<PlayerStateId, IPlayerState> PlayerStates = new();
        private IPlayerState _currentState = new EmptyState();
        private IPlayerState _transitionToState = null;

        public void TransitionTo(PlayerStateId playerStateId)
        {
            _transitionToState = PlayerStates[playerStateId];
            Debug.Log("transitioning to " + playerStateId);
        }

        public void Update()
        {
            TransitionToStateIfRequested();
            _currentState.Update();
        }

        public void FixedUpdate()
        {
            _currentState.FixedUpdate();
        }

        public void End()
        {
            _transitionToState = null;
            _currentState.End();
        }

        private void TransitionToStateIfRequested()
        {
            if (_transitionToState == null)
            {
                return;
            }
            
            _currentState.End();
            _currentState = _transitionToState;
            _currentState.Start();
            _transitionToState = null;
        }
    }

    class EmptyState : IPlayerState
    {
        public void Start()
        {
            
        }

        public void Update()
        {
            
        }

        public void FixedUpdate()
        {
            
        }

        public void End()
        {
            
        }
    }
}

