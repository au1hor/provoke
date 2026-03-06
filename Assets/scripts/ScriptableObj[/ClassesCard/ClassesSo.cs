using System;
using UnityEngine;
public enum ClassType{
        Slayer,
        Warrior,
        Espada
    }

 [CreateAssetMenu (fileName = "ClassesSo",menuName ="Scriptable Objects/ClassesSo")]
public class ClassesSo : ScriptableObject
{
    public ClassType classType;
    public StatsRange damage;
    public StatsRange life;
    public StatsRange speed;
    public StatsRange atackSpeed;



}
