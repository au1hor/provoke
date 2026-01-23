using UnityEngine;

public class Char
{
    public string name{get; protected set;}
    public float damage{get; protected set;}
    public float maxHealth{get; protected set;}
    public float currentHealth{get; protected set;}
    public float moveSpeed{get; protected set;}

    public Char(string name,float damage, float maxHealth,float moveSpeed){
        this.name = name;
        this.damage = damage;
        this.maxHealth = maxHealth;
        currentHealth = currentHealth;
        this.moveSpeed = moveSpeed;
    }
    public virtual void Apresentation()
    {
        Debug.Log("This character is a normal char but he have lot dreams!!!\n Keep dream and acting author! so that child realize his dreamns and be happy");
    }
}
