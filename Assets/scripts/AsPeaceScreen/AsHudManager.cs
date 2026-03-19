using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;


public class AsHud : MonoBehaviour
{
    public GameObject[] points;
    public Sprite circle;
    public Sprite circleFull;
    public GameObject currentNotice;
    // change screens
    public int actualScene = 0;
    public GameObject[] screens;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ClickOnPoint(GameObject button){
        Image image = button.GetComponent<Image>();
        for (int i = 0; i < points.Length; i++)
        {
            points[i].GetComponent<Image>().sprite = circle;
           
            
        }
        image.sprite = circleFull;
        GameObject notice = button.GetComponent<PointBehaviour>().Notice;
        ChangeCurrentNotice(notice);
    }
    public void ChangeCurrentNotice(GameObject notice){
        currentNotice.gameObject.SetActive(false);
        currentNotice = notice;
        notice.gameObject.SetActive(true);
    }

    public void ChangeScreen(int index){        
        screens[index].gameObject.SetActive(true);
        screens[actualScene].gameObject.SetActive(false);
        actualScene = index;
    }
    public void DisplayActualScene(){

    }
    private void Start(){
        points[1].GetComponent<Image>().sprite = circleFull;
    }
}
