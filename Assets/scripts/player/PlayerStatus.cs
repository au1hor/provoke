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
   public void incressXp(float mount)
   {
      xpBar.value += mount;
      if (xpBar.value >= 100)
      {
         int levelUps;
         float rest = (xpBar.value + mount) - 100;
         if (rest >= 100)
         {
            levelUps = (int)rest / 100;
            for (int i = 0; i < levelUps; i++)
            {
               rest -=100;
               Player.GainLevel(rest);
            }
         }else
         {
             Player.GainLevel(rest);
         }
         xpBar.value = rest;
         Debug.Log(rest);
         
      }
      
   }
   private void Start() {
      Player = new Char("Nameless",0,10,0,1,0);
   }
   }
