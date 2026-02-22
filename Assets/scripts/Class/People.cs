using UnityEngine;

public class People
{
    // esssa vai ser a primeira classe 
    public string name;
    public float health;
    public int humor;
    public float physical;
    public float mental;
    public float money;
    public float grindLevel;
    
    public People(string name,float health,int humor, float physical, float money,float grindLevel)
    {
        this.name = name;
        this.health = health;
        this.humor = humor;
        this.physical = physical;
        this.money = money;
        this.grindLevel = grindLevel;
    }

}
