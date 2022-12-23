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

    public void Render(Level level, int startX)
    {
        var queue = level.GetAll();

        int count = -1;
        
        foreach (int height in queue)
        {
            count++;
            if (height < 0)
            {
                continue;
            }
            int posX = count + startX;
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
