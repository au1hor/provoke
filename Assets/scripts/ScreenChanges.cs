using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenChanges : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject AtributeScreen;
    public GameObject CatMidleFinger;

    
    public void ChangeFirtsAtributes()
    {
        StartScreen.gameObject.SetActive(false);
        AtributeScreen.gameObject.SetActive(true);
    }
     public void ChangeToDesktopScene()
    {
        SceneManager.LoadScene("deskTop");
    }
    public void WarningNotCoded()
    {
        StartCoroutine(catMidleFingerSay());
    }
    IEnumerator catMidleFingerSay(){
        
        CatMidleFinger.gameObject.SetActive(true);
        CatMidleFinger.GetComponent<AudioSource>().time = 0.25f;
        yield return new WaitForSeconds(0.5f);
        CatMidleFinger.gameObject.SetActive(false);
        

    }
}
