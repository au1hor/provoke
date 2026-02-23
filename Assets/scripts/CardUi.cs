using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Analytics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CardUi : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text DescriptionStatus;
    public TMP_Text DescriptionStart;
    public GameObject DetailsScreen;
    public GameObject DetailsCard;
    public CardsSo cardsSo;
    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("entrou");
        DescriptionStatus.text = BetterDescriptionStats();
         DescriptionStart.text = DescriptionStartSet();
        
        
    }
     public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse saiu ");
        
      
    }
    public void ClickOnCard()
    {
        DetailsScreen.gameObject.SetActive(true);
       

    }
    public string DescriptionStartSet()
    {
        string description = "";
        switch (cardsSo.startItem)
        {
            case StartItem.Cat:
            description = $"You follow the same routine as always: work, school, and games to have fun in your free time. You feel more like one of those people who blend into the crowd, without many dreams, without goals, just existing. You are alone, you never knew your father or your mother, the only family you have is a beautiful black <color=purple>cat</color>. You keep yourself busy, avoiding any moment of quiet, because when you stop, the future seems oppressive and empty, something too painful even to think about.You live in a dorm room at college, surrounded by silence, and the <color=purple>cat</color>, the only companion in this lonely existence, watches you with eyes that seem to understand more than you would like to admit.One day, you hear people from college talking about the new season of a game called AsPeace. You've never been a big fan of games, but it seems like a good way to kill time. You're not looking for meaning in it, just a way to forget about the monotony, the loneliness, and the weight of the future.";
            break;
            case StartItem.Dog:
            break;
            case StartItem.Katana:
            description = $"A young, ambitious man, full of dreams and passionate about anime, always longing to be the protagonist. He enjoyed playing games because it made him feel like he was living in a real anime – epic battles, combos, and victories. These games were his escape. However, as he grew older, his hobbies were consumed by the weight of life. He still enjoyed playing with friends, but time, family pressure, and necessity forced everyone to play less and take on more conventional jobs. This didn't mean the end of his ambitions, but it was a chapter that needed to be overcome.Focused on college and work, he maintained a positive mindset, always playing in his free time, dreaming of a life where he could play whenever he wanted. But, despite becoming good at most games, something always seemed to be missing – a sense of freedom, a world where his movements weren't constantly restricted by obligations and expectations.That was when he decided to try this game that had just been released globally, called AsPeACE. It seemed like a chance to escape, a world where he could find the freedom he was desperately seeking.";
            break;
            case StartItem.CoffeMachine:
            description = $"A man, a cup of coffee, and games.";
            break;
            case StartItem.ButlerRobbot:
            description = $"Rich kid, demanding family, strict routine, lots of money.";
            break;
            case StartItem.OnlyYourself:
            description = $"A man with only himself left, even his hair was taken by alopecia.";
            break;
           
        }
        return description;
    }
    public string BetterDescriptionStats()
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
            string curencySym = "";
             if (stats.Key == "Money" || stats.Key == "Income")
            {
                curencySym = "R$";
            }
            if (stats.Value > 0)
            {
                description += $" <color=green>{stats.Value}</color>{curencySym} {stats.Key},";
            }else if (stats.Value < 0)  
            {
                description += $" <color=red>{stats.Value}</color>{curencySym} {stats.Key},";
            }else
            {
                description += $" <color=white>{stats.Value}</color>{curencySym} {stats.Key},";
            }
            if (stats.Key == "Income")
            {
                description += $"\nYour Start item is a: <color=Purple>{startItem}</color>.";
            }
           
        }
        
        return description;
    }
    private void Update() {
        if (Input.GetMouseButton(1))
        {
            DetailsScreen.gameObject.SetActive(false);
        }
    }
}
