using UnityEngine;

 public enum TypeOfCard
    {
        MultiChange,
        DirectBuff,
        DirectDebuf,
        Stack,
    }
public enum StartItem
{
    Cat,
    Dog,
    Katanna,
    CoffeMachine,
}
[CreateAssetMenu(fileName = "CardsSo", menuName = "Scriptable Objects/CardsSo")]
public class CardsSo : ScriptableObject
{
    public string CardName;
    public float healthChng;
    public int humorChng;
    public float physicalChng;
    public float mentalChng;
    public float moneyChng;
    public float incomeChng;
    public StartItem startItem;
    public TypeOfCard cardType;
}
