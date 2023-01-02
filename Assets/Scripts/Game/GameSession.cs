namespace Game
{
    public class GameSession
    {
        public int Level { get; private set; }

        public GameSession(int level)
        {
            Level = level;
        }

        public void NextLevel()
        {
            Level++;
        }

        public void StartNewSession()
        {
            Level = 1;
        }
    }
}