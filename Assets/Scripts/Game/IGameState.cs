namespace Game
{
    public interface IGameState
    {
        public void Start();

        public void Update();

        public void FixedUpdate();

        public void End();
    }
}