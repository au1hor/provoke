using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class CharManager : MonoBehaviour
{
    Char player;
    
    public void createPlayer(TMP_InputField name)
    {
        player = new Char(name.text,1,100,12);
    }
    private void Update() {
        if (player != null)
        {
            player.apresentation();
        }
    }
}
