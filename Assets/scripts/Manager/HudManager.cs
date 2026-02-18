using JetBrains.Annotations;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public GameObject prefabPopDmg;
    TMP_Text textPopDamage;
    public Color colorDefault;
    public float fontSizeDefault;
    public static HudManager Instance{get;private set;}
    public float impulseForce;
    private float impulseForceDefault;
     public Slider xpBar;
    private void Awake() {
        if (Instance != null && Instance !=this)
        {
            Destroy(this);
        }else
        {
            Instance =this;
        }
    } 
    private void Start() {
        textPopDamage = prefabPopDmg.GetComponentInChildren<TMP_Text>();
        fontSizeDefault = textPopDamage.fontSize;
        colorDefault = Color.white;
        impulseForceDefault = impulseForce;
    }   

    public void PopUpDamage(float damage,GameObject target)
    {
        Vector2 direction = new Vector2(UnityEngine.Random.Range(-1f,1f),1 * impulseForce);
        GameObject popDmg = Instantiate(prefabPopDmg,target.transform.position,quaternion.identity);
        popDmg.GetComponent<Rigidbody2D>().AddForce(direction,ForceMode2D.Impulse);
        popDmg.GetComponent<PopUp>().textString = damage.ToString();
        Destroy(popDmg,0.7f);
    }
    public void EspecialHit(Color color,float fontSize)
    {
        impulseForce = 1.5f;
        textPopDamage.color = color;
        textPopDamage.fontSize = fontSize;

    }
    public void resetToNormalHIt()
    {
        impulseForce = impulseForceDefault;
        textPopDamage.color = colorDefault;
        textPopDamage.fontSize = fontSizeDefault;
    }
}
