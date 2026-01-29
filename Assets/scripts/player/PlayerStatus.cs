using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// placeHolder antes do bglh ficar serio
public class PlayerStatus : MonoBehaviour
{
   Char Player;
   public Slider xpBar;
   public void createCharPlayer(string name)
   {
      
   }
   public void IncressXp(float mount)
   {
      if (xpBar.value + mount > 100)
      {
         int levelUps;
         float rest = xpBar.value + mount- 100;
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
         xpBar.value = 0;
         Player.GainLevel();  
         return;
      }
      xpBar.value += mount;
      
   }
   private void Start() {
      Player = new Char("Nameless",0,10,0,1,0);
   }
   }
