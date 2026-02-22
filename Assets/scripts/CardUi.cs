using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CardUi : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("entrou");
        
    }
     public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse saiu ");
      
    }
}
