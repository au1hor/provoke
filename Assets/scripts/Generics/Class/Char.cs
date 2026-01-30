using UnityEngine;
 [System.Serializable]
public class Char
{
    public string name{get; protected set;}
    public float strength{get; protected set;}
    public float maxHealth{get; protected set;}
    public float currentHealth{get; protected set;}
    public float moveSpeed{get; protected set;}
    public float currentXp{get; protected set;}
    public float xpMulti{get; protected set;}
    public int level{get; protected set;}

    public Char(string name,float damage, float maxHealth,float moveSpeed,float xpMulti,float currentXp,int level = 0){
        this.name = name;
        this.strength = damage;
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        this.moveSpeed = moveSpeed;
        this.currentXp = currentXp;
        this.xpMulti = xpMulti;
        this.level =level;
    }
    public virtual void Apresentation()
    {
        Debug.Log("This character is a normal char but he have lot dreams!!!\n Keep dream and acting author! so that child realize his dreamns and be happy");
    }
    // Ganhos
    public void GainLevel(float restXp = 0)
    {
        currentXp = restXp;
        level += 1;
        Debug.Log("Level: "+ this.level);
    }
 
    
}
