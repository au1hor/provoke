using UnityEngine;

public class Char
{
    public string name{get; private set;}
    public int level{get; private set;}
    public float LifePoints{get; private set;}
    public float strength{get; private set;}


    public Char(string name, int level, float LifePoints, float strength)
    {
        this.name = name;
        this.level = level;
        this.LifePoints = LifePoints;
        this.strength = strength;
    }
    public virtual void apresentation()
    {
        Debug.Log($"Nome: {name}\nLevel: {level}\nLifePonints: {LifePoints}\nStrength: {strength} ");
    }
}
