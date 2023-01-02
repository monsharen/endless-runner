
using UnityEngine;

public class LevelGenerator
{
    private const int MaxHeight = 8;

    public static Level.Level Generate(int platformLengthStart, int numberOfPlatforms, int spaceBetweenPlatforms)
    {

        Level.Level level = new Level.Level();

        // Generate start platform
        GeneratePlatform(platformLengthStart * 4, 0, level);

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            // And space before platform
            GeneratePlatform(spaceBetweenPlatforms, -1, level);
            
            int platformHeight = Random.Range(0, MaxHeight);
            int platformLength = Random.Range(platformLengthStart, platformLengthStart * 3);

            // Generate platform
            GeneratePlatform(platformLength, platformHeight, level);
        }

        return level;
    }

    private static void GeneratePlatform(int length, int height, Level.Level level)
    {
        for (int x = 0; x < length; x++)
        {
            level.Add(height);
        }
    }
}
