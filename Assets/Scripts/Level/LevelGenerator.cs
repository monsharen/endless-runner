
using UnityEngine;

public class LevelGenerator
{
    private const int MaxHeight = 8;

    public static Level Generate(int platformLengthStart, int numberOfPlatforms, int spaceBetweenPlatforms)
    {

        Level level = new Level();
        
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            int platformHeight = Random.Range(0, MaxHeight);
            int platformLength = Random.Range(platformLengthStart, platformLengthStart * 3);
            
            for (int x = 0; x < platformLength; x++)
            {
                level.Add(platformHeight);
            }

            for (int x = 0; x < spaceBetweenPlatforms; x++)
            {
                level.Add(-1);
            }
        }

        return level;
    }
}
