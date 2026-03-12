using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public Data data;
    public Char Player;
    // data range
    public ClassesSo classesSo;
    //
    public string nick;
    public float xp;
    public float maxXp;
    public int level;
    public float maxLife;
    public float currentLife;
    public float damage;
    public float speed;
    public float atackSpeed;

    
    public void Start(){
        GetData();
        GetStatus();
        currentLife = maxLife;
    }
    public void GetData(){
        GameObject dataObj = GameObject.FindGameObjectWithTag("Data");
        if(dataObj == null){
            Debug.Log("Inciando a criação da Data");
            GameObject dataOBj = new("DataPlaceholder");
            data = dataOBj.AddComponent<Data>();
            data.Player = new createChar("DataNotFound!!!",classesSo).Create(classesSo);
            data.playerName = "Eipsiudoidinhadoforro";
            data.playerNick = "DataNotFound!!!!!";
            Data.Instance.Player.life = 999;
        }else{
            data = dataObj.GetComponent<Data>();
        }
        Player = Data.Instance.Player;
    }
    private void GetStatus(){
        nick = data.playerNick;
        maxLife = data.Player.life;
        damage = data.Player.damage;
        speed = data.Player.speed;
        atackSpeed = data.Player.atackSpeed;
        xp = data.Player.currentXp;
    }
    public void GainXp(float amount){
        Player.IncressXp(amount);
        xp = Player.currentXp;
        while(xp>= maxXp){
            level++;
            xp -= maxXp;
            //maxXp *= 0.10f; // max xp ta dando bug pra krl pq essa logica ta merda arruamr 
        }
        Debug.Log("oxecckrl");
    }
}
