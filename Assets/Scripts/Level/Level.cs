using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class Level
    {

        private readonly List<int> _height = new List<int>();
        public int GetHeightAt(int x)
        {
            return _height[x];
        }

        public void Add(int height)
        {
            _height.Add(height);
        }

        public List<int> GetAll()
        {
            return _height;
        }

        public int GetLength()
        {
            return _height.Count;
        }
    }
}
