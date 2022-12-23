using UnityEngine;

public static class UnitConverter
{
    public static int EngineXToLevelX(float x)
    {
        return Mathf.FloorToInt(x);
    }
    
    public static int EngineYToLevelY(float y)
    {
        return Mathf.RoundToInt(y);
    }
}
