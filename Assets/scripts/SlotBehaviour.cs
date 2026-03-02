
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotBehaviour : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Image Icon;
    public Color highlightColor = Color.yellow;
    Image Border;
    public float a;
    public void Start(){
        Border = this.GetComponent<Image>();
    }
    public void OnPointerEnter(PointerEventData data){
        Debug.Log("DEntro");
        Border.color = highlightColor;
    }
    public void OnPointerExit(PointerEventData data){
            Debug.Log("Fora");
            Border.color = Color.black;
    }
}
