using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CardUi : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text DescriptionStatus;
    public CardsSo cardsSo;
    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("entrou");
        DescriptionStatus.text = BetterDescription();
        
    }
     public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse saiu ");
      
    }
    public string BetterDescription()
    {
        string description = $"";
        var health = cardsSo.healthChng;
        var humor = cardsSo.humorChng;
        var physical = cardsSo.physicalChng;
        var mental = cardsSo.mentalChng;
        var money = cardsSo.moneyChng;
        var income = cardsSo.incomeChng;
        StartItem startItem = cardsSo.startItem;
        Dictionary<String,float> Vars = new Dictionary<string, float>
        {
            {"Health",health},
            {"Humor",humor},
            {"Physical",physical},
            {"Mental",mental},
            {"Money",money},
            {"Income",income},
        };
        foreach (var stats in Vars)
        {
            if (stats.Value > 0)
            {
                description += $"<color=green>{stats.Value}</color> {stats.Key},";
            }else if (stats.Value < 0)
            {
                description += $"<color=red>{stats.Value}</color> {stats.Key},";
            }else
            {
                description += $"<color=white>{stats.Value}</color> {stats.Key},";
            }
            if (stats.Key == "Income")
            {
                description += $"\nYour Start item is a: <color=Purple>{startItem}</color>.";
            }
        }
        
        return description;
    }
}
