using TMPro;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public TMP_Text text;
    public string textString;

    private void Start() {
        text.text = textString;
    }
    
}
