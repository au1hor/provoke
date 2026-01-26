using UnityEngine;

public class Char
{
    public string name{get; protected set;}
    public float strength{get; protected set;}
    public float maxHealth{get; protected set;}
    public float currentHealth{get; protected set;}
    public float moveSpeed{get; protected set;}
    public float xpMulti{get; protected set;}

    public Char(string name,float damage, float maxHealth,float moveSpeed,float xpMulti){
        this.name = name;
        this.strength = damage;
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        this.moveSpeed = moveSpeed;
        this.xpMulti = xpMulti;
    }
    public virtual void Apresentation()
    {
        Debug.Log("This character is a normal char but he have lot dreams!!!\n Keep dream and acting author! so that child realize his dreamns and be happy");
    }
    /// <summary>
    /// Seta o dano do caba bixo
    /// </summary>
    /// <param name="incressValor">Valor a ser somado em float</param>
    /// <param name="bonusValor">Se for o caso de bonus bota algum valor aqui</param>
    public void setStrength(float incressValor, float bonusValor = 0)
    {
        
    }
    public float getStrength()
    {
        return strength;
    }
    public float GetmaxHealth()
    {
        return maxHealth;
    }
    public float GetSpeed()
    {
        return moveSpeed;
    }
    public float getXpMulti()
    {
        return xpMulti;
    }
    
}
