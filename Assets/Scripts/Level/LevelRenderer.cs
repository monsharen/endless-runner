using UnityEngine;

public class LevelRenderer
{

    private readonly GameObject _platformPrefab;
    private readonly GameObject _parentNode;
    private readonly float platformSizeAdjustment = 0.5f;

    public LevelRenderer(GameObject platformPrefab, GameObject parentNode)
    {
        _platformPrefab = platformPrefab;
        _parentNode = parentNode;
    }

    public void Render(Level.Level level, int startX)
    {
        int count = 0;
        foreach (var platform in level.GetAllPlatforms())
        {
            if (platform.Height >= 0)
            {
                float platformStartX = (count + startX) - 1;
                RenderPlatform(platformStartX, platform.Length, platform.Height);
            }
            
            count += platform.Length;
        }
    }

    private void RenderPlatform(float platformStartX, int length, int height)
    {
        for (int i = 1; i < length; i++)
        {
            float posX = i + platformStartX;
            var gameObject = Object.Instantiate(_platformPrefab, new Vector3(posX + platformSizeAdjustment, height, 0), Quaternion.identity);
            gameObject.transform.parent = _parentNode.transform;
        }
    }

    public void DestroyAll()
    {
        foreach (Transform child in _parentNode.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }
}
