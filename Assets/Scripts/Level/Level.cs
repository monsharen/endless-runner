using System.Collections.Generic;

namespace Level
{
    public class Level
    {

        private readonly List<int> _height = new List<int>();
        private readonly List<Platform> _platforms = new List<Platform>();
        public int GetHeightAt(int x)
        {
            return _height[x];
        }

        public void Add(Platform platform)
        {
            _platforms.Add(platform);
            for (int i = 0; i < platform.Length; i++)
            {
                _height.Add(platform.Height);
            }
        }

        public List<Platform> GetAllPlatforms()
        {
            return _platforms;
        }

        public int GetLength()
        {
            return _height.Count;
        }
    }
}
