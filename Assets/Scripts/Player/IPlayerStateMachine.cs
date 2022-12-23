namespace Player
{
    public interface IPlayerStateMachine
    {
        public void TransitionTo(PlayerStateId playerStateId);

        public void Update();

        public void FixedUpdate();

        public void End();
    }
}