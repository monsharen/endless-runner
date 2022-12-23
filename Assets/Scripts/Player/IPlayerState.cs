namespace Player
{
    public interface IPlayerState
    {
        public void Start();
        public void Update();

        public void FixedUpdate();

        public void End();
    }
}