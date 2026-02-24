using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoginScene : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public TMP_InputField Login;
    public TMP_InputField Password;
    
    public TMP_Text ShowCurrencyArea;
    public void OnPointerEnter(PointerEventData data)
    {
        ShowCurrencyArea.text = "AsPeace - Login/Register";
    }
    public void OnPointerExit(PointerEventData data)
    {
         ShowCurrencyArea.text = "Desktop  - Area Rest";
    }
      public void clickInX()
    {
        this.gameObject.SetActive(false);
       
    }
    public void changeFocusInput()
    {
        if (Login.isFocused)
        {
            Password.Select();
        }else
        {
            Login.Select();
        }
    }
    public void EnterInTheGame()
    {
        SceneManager.LoadScene("StartRpgPlayer");
    }
    private void Update() {
         if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Return) )
        {
            changeFocusInput();
        }
    }
}
