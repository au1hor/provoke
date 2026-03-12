using UnityEngine;

public abstract class Char
{
    public string nick;
    public ClassesSo classesSo;
    public ClassType classeType;
    public float damage;
    public float life;
    public float speed;
    public float atackSpeed;
    public float maxXp;
    public float currentXp;
    public Char(string nick,ClassesSo classesSo,ClassType classe,float damage, float life, float speed, float atackSpeed,float maxXp,float currentXp){
        this.nick = nick;
        this.classesSo = classesSo;
        this.classeType = classe;
        this.damage = damage;
        this.life = life;
        this.speed = speed;
        this.atackSpeed = atackSpeed;
        this.maxXp = 100;
        this.currentXp = 0;
    }
    
    public virtual void GetDamage(float damage){
        life -= damage;
    }
    public virtual void IncressXp(float amount){
        currentXp += amount;
    }
    public virtual void Hey(){
        Debug.Log($"My name is {this.nick}!!!\n");
    }
    
}
public class Warrior : Char
{
    public Warrior(string nick,ClassesSo classesSo,ClassType classe,float damage,float life,float speed,float attackSpeed,float maxXp,float currentXp)
        : base(nick,classesSo,classe, damage, life, speed, attackSpeed,maxXp,currentXp){}
    public void HeavyAttack()
    {
        Debug.Log("Warrior atacando");
    }
    public override void Hey()
    {
        base.Hey();
        Debug.Log($"{nick}Hey a simple warrior my status :{damage},{life},{speed},{atackSpeed}");
    }
    
}
public class Slayer : Char
{
    public Slayer(string nick,ClassesSo classesSo,ClassType classe,float damage,float life,float speed,float attackSpeed,float maxXp,float currentXp)
        : base(nick,classesSo,classe, damage, life, speed, attackSpeed,maxXp,currentXp){}
    public void attackSuddenly()
    {
        Debug.Log("Slayer atacando");
    }
    public override void Hey()
    {
        base.Hey();
        Debug.Log($"Hey a simple slayer my status :{damage},{life},{speed},{atackSpeed}");
    }
}
public class Espada : Char
{
    public Espada(string nick,ClassesSo classesSo,ClassType classe,float damage,float life,float speed,float attackSpeed,float maxXp,float currentXp)
        : base(nick,classesSo,classe, damage, life, speed, attackSpeed,maxXp,currentXp){}
    public void slash()
    {
        Debug.Log("Espada atacando");
    }
    public override void Hey()
    {
         base.Hey();
        Debug.Log($"Hey a simple Espadamy status :{damage},{life},{speed},{atackSpeed}");
    }
}
