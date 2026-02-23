using UnityEngine;

public class People
{
    // esssa vai ser a primeira classe 
    public string name;
    public float health;
    public float humor;
    public float physical;
    public float mental;
    public float money;
    public float income;
    public float grindLevel;
    
    public People(string name,float health,float humor, float physical, float money,float income,float grindLevel)
    {
        this.name = name;
        this.health = health;
        this.humor = humor;
        this.physical = physical;
        this.money = money;
        this.income = income;
        this.grindLevel = grindLevel;
    }

}
