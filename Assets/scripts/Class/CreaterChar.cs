using NUnit.Framework.Internal;
using UnityEngine;
public class createChar{
    public string nick;
    public ClassesSo classesSo;
    public ClassType classType;
    public StatsRange damage;
    public StatsRange life;
    public StatsRange speed;
    public StatsRange atackSpeed;
    public float maxXp;
    public float currentXp;
    public createChar(string nick,ClassesSo classesSo){
        this.nick = nick;
        this.classesSo = classesSo;
        this.classType = classesSo.classType;
        this.damage = classesSo.damage;
        this.life = classesSo.life;
        this.speed = classesSo.speed;
        this.atackSpeed = classesSo.atackSpeed;
        this.maxXp = 100;
        this.currentXp = 0;
    }
    public Char Create(ClassesSo classesSo){
        var damage = classesSo.damage.getRandom();
        var life = classesSo.life.getRandom();
        var speed = classesSo.speed.getRandom();
        var atackSpeed = classesSo.atackSpeed.getRandom();
        switch (classType)
        {
            default: 
            return new Slayer(nick,classesSo,classType,damage,life,speed,atackSpeed,maxXp,currentXp);
            case ClassType.Warrior:
            return new Warrior(nick,classesSo,classType,damage,life,speed,atackSpeed,maxXp,currentXp);
            case ClassType.Espada:
            return new Espada(nick,classesSo,classType,damage,life,speed,atackSpeed,maxXp,currentXp);
        }
    }
}