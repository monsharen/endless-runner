using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameStateMachine
    {
        public readonly Dictionary<GameStateId, IGameState> GameStates = new();
        private IGameState _currentState = new EmptyState();
        private IGameState _transitionToState = null;

        public void TransitionTo(GameStateId stateId)
        {
            _transitionToState = GameStates[stateId];
            
            //Debug.Log("transition to game state " + stateId);
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

    class EmptyState : IGameState
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