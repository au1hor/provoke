using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AppsDesaktop : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public TMP_Text showCurrencyArea;
    public void OnPointerEnter(PointerEventData data)
    {
        this.gameObject.transform.localScale = new Vector2(1.2f,1.2f);
         showCurrencyArea.text = this.gameObject.name;
    }
    public void OnPointerExit(PointerEventData data)
    {
        this.gameObject.transform.localScale = Vector2.one;
         showCurrencyArea.text = "Desktop  - Area Rest";
    }
}
