using TMPro;

namespace UI
{
    public class UIManager
    {
        
        private readonly TextMeshProUGUI _jumps;
        private readonly TextMeshProUGUI _deaths;
        private readonly TextMeshProUGUI _coins;
        private readonly TextMeshProUGUI _level;

        public UIManager(
            TextMeshProUGUI jumps, 
            TextMeshProUGUI deaths, 
            TextMeshProUGUI coins, 
            TextMeshProUGUI level)
        {
            _jumps = jumps;
            _deaths = deaths;
            _coins = coins;
            _level = level;
        }

        public void UpdateJumps(int i)
        {
            _jumps.text = "" + i;
        }
        
        public void UpdateDeaths(int i)
        {
            _deaths.text = "" + i;
        }
        
        public void UpdateCoins(int i)
        {
            _coins.text = "" + i;
        }
        
        public void UpdateLevel(int i)
        {
            _level.text = "" + i;
        }
    }
}