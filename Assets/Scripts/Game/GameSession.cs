using UI;

namespace Game
{
    public class GameSession
    {

        private readonly UIManager _uiManager;

        public int Level { get; private set; }

        public int NumberOfJumps { get; private set; }
        
        public int Deaths { get; private set; }
        
        public int Coins { get; private set; }

        public GameSession(int level, UIManager uiManager)
        {
            Level = level;
            _uiManager = uiManager;
        }

        public void CountJump()
        {
            NumberOfJumps++;
            
            _uiManager.UpdateJumps(NumberOfJumps);
        }
        
        public void CountDeath()
        {
            Deaths++;
            
            _uiManager.UpdateDeaths(Deaths);
        }
        
        public void CountCoin()
        {
            Coins++;
            
            _uiManager.UpdateCoins(Coins);
        }

        public void NextLevel()
        {
            Level++;
            
            _uiManager.UpdateLevel(Level);
        }

        public void StartNewSession()
        {
            Level = 1;
            Coins = 0;
            NumberOfJumps = 0;
            
            _uiManager.UpdateLevel(Level);
            _uiManager.UpdateCoins(Coins);
            _uiManager.UpdateJumps(NumberOfJumps);
        }
    }
}