using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenChanges : MonoBehaviour
{
    public GameObject StartScreen;
    public GameObject AtributeScreen;
    
    public enum Scenes
    {
        StartScene,
        SelectFirstAtributes
    }

    public void changeScene(Scenes scenes)
    {
        SceneManager.LoadScene(scenes.ToString());
    
    }
    public void ChangeToStartScreen()
    {
        changeScene(Scenes.StartScene);
    }
     public void ChangeToInicAtributes()
    {
        changeScene(Scenes.SelectFirstAtributes);
    }
    
}
