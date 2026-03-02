using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("FigthScene");
    }
}