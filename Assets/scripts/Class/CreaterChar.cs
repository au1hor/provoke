using UnityEngine;
public class createChar{
    public string nick;
    public ClassesSo classesSo;
    public ClassType classType;
    public StatsRange damage;
    public StatsRange life;
    public StatsRange speed;
    public StatsRange atackSpeed;
    public createChar(string nick,ClassesSo classesSo,ClassType classType,StatsRange damage, StatsRange life , StatsRange speed, StatsRange atackSpeed){
        this.nick = nick;
        this.classesSo = classesSo;
        this.classType = classType;
        this.damage = damage;
        this.life = life;
        this.speed = speed;
        this.atackSpeed = atackSpeed;
    }
    public Char Create(ClassesSo classesSo){
        var damage = classesSo.damage.getRandom();
        var life = classesSo.life.getRandom();
        var speed = classesSo.speed.getRandom();
        var atackSpeed = classesSo.atackSpeed.getRandom();
        switch (classType)
        {
            default: 
            return new Slayer(nick,classesSo,classType,damage,life,speed,atackSpeed);
            //
            case ClassType.Warrior:
            return new Warrior(nick,classesSo,classType,damage,life,speed,atackSpeed);
            //
            case ClassType.Espada:
            return new Espada(nick,classesSo,classType,damage,life,speed,atackSpeed);
        }
    }
 
}