using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public Scene FightScene;
    public void ChangeToFightScene()
    {
        SceneManager.LoadScene("FigthScene");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
