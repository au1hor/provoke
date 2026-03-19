using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LocalesBehaviour : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnPointerEnter(PointerEventData data){
        this.gameObject.GetComponent<Outline>().enabled = true;
        
    }
    public void OnPointerExit(PointerEventData data){
        this.gameObject.GetComponent<Outline>().enabled = false;
    }
    
}
