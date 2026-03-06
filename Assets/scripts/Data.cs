using UnityEngine;

public class Data : MonoBehaviour
{
    public string playerName = "uNaMeD";
    public string playerNick = "uNiCkEd";
    public Char Player;
    public static Data Instance{get;private set;}
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
          if (Instance != null && Instance !=this)
        {
            Destroy(this);
        }else
        {
            Instance = this;
        }
    }
    public void Update(){
        Debug.Log(playerNick);
    }
}
