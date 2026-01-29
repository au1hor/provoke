using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour
{
    public TMPro.TMP_InputField nameInput;
    public void LockInput(TMPro.TMP_InputField input)
    {
        if (input.text.Length <0)
        {
            Debug.Log("Empty text");
            return;
        }
        Debug.Log(input.text);
    }
    private void Update() {
        nameInput.onEndEdit.AddListener(delegate {LockInput(nameInput);});
    }
    
}
