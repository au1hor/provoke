using UnityEngine;

[System.Serializable]
public struct StatsRange
{
    public float min;
    public float max;
    public float getRandom(){
        return Random.Range(min,max);
    }
}