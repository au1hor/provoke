using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseButton : MonoBehaviour
{
    public void onclick()
    {
        SceneManager.LoadScene("FigthScene");
    }
   
}
