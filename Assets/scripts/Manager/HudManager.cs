using JetBrains.Annotations;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public GameObject prefabPopDmg;
    TMP_Text textPopDamage;
    public Color colorDefault;
    public float fontSizeDefault;
    public float impulseForce;
    private float impulseForceDefault;
    public Slider xpBar;
    // Inventory
    public GameObject InventoryObj;
    public GameObject[] slots;
    public TMP_Text nick;
    public TMP_Text damage;
    public TMP_Text life;
    public TMP_Text speed;
    // HUD PLAYER
    public Slider hpbar;
    public TMP_Text atackSpeed;
     public static HudManager Instance{get;private set;}
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
    private void Update(){
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryShow();
        }
    }
    public void UpdateInventoryHud(){
        data data = GameObject.FindGameObjectWithTag("Data").GetComponent<data>();
        Char Player = data.Instance.Player;
        nick.text = Player.nick;
        damage.text = $"Base Damage: {Player.damage:f2}";
        life.text = $"LifePoints: {Player.life:f2}/{Player.life:f2}";
        speed.text = $"Speed: {Player.speed:f2}";
        atackSpeed.text = $"AtackSpeed: {Player.atackSpeed:f2}";

    }
    public void InventoryShow(){
       
        if (InventoryObj.activeSelf)
        {
            InventoryObj.gameObject.SetActive(false);
        }
        else
        {
             UpdateInventoryHud();
            InventoryObj.gameObject.SetActive(true);
        }
    }
    public void PopUpDamage(float damage,GameObject target)
    {
        Vector2 direction = new Vector2(UnityEngine.Random.Range(-1f,1f),1 * impulseForce);
        GameObject popDmg = Instantiate(prefabPopDmg,target.transform.position,quaternion.identity);
        popDmg.GetComponent<Rigidbody2D>().AddForce(direction,ForceMode2D.Impulse);
        popDmg.GetComponent<PopUp>().textString = $"{damage:f2}";
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
