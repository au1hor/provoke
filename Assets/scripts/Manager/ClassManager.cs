using TMPro;
using UnityEngine;

public class ClassManager : MonoBehaviour
{
    public TMP_Text SelectText;
    public data data;
    public string nick;
    Char Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start(){
       
    }
    public void ClickIntheCard(GameObject card){
         if (data == null)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Data");
            if (obj == null)
            {
                nick ="nao achou :p";
            }else{

                data = obj.GetComponent<data>();
                nick = data.playerNick;
            }
          
        
        }
        Color cor = card.GetComponent<ClassesButton>().color;
        SelectText.gameObject.SetActive(true);
        SelectText.text = $"Selected Card: <color=#{ColorUtility.ToHtmlStringRGB(cor)}>{card.name}</color>";
        ClassesSo classesSo = card.GetComponent<ClassesButton>().Classe;
        Player = new createChar(nick,classesSo,classesSo.classType,classesSo.damage,classesSo.life,classesSo.speed,classesSo.atackSpeed).Create(classesSo);
        Player.Hey();
        if (data!= null)
        {
            data.Player = Player;
        }





        
    
      
        
        
    } 
}
