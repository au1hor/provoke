using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public Slider slider;

    private void Start() {
        slider.maxValue = 100;
    }
}
