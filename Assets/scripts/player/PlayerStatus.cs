using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// placeHolder antes do bglh ficar serio
public class PlayerStatus : MonoBehaviour
{
   private void Awake() {
      PlayerStatus [] objs = FindObjectsByType<PlayerStatus>(FindObjectsSortMode.None);
      if (objs.Length >1)
      {
         Destroy(this.gameObject);
         
      }
      DontDestroyOnLoad(this.gameObject);
   }
   public Char Player;
   public Slider xpBar;
   public void IncressXp(float mount)
   {
      if (xpBar.value * Player.xpMulti + mount > 100)
      {
         int levelUps;
         float rest = xpBar.value * Player.xpMulti + mount- 100;
         levelUps  = (int)rest / 100;
         rest = rest % 100;
         for (int i = 0; i < levelUps + 1; i++)
         {
            if (i == levelUps)
            {
               Player.GainLevel(rest);
               Debug.Log("Break");
               break;
            }
            Player.GainLevel();
         }
         Debug.Log("Rest: " + rest);
         xpBar.value = rest;
         return;
      }
      else if (xpBar.value == 100)
      {
         xpBar.value *=  Player.xpMulti + mount;
         xpBar.value = 0;
         Player.GainLevel();  
         return;
      }
      
      
   }
   private void Start() {
      Player = new Char("Nameless",0,10,10,10,0);
   }
   }
