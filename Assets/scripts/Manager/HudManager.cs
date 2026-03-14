using JetBrains.Annotations;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    // data
    public Data data;
    public GameObject Player;
    public PlayerStatus playerStatus;
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
    public TMP_Text nivelTmp;
    public TMP_Text nickTmp;
    public TMP_Text damageTmp;
    public TMP_Text lifeTmp;
    public TMP_Text speedTmp;
    // HUD PLAYER
    public Slider hpbar;
    public TMP_Text atackSpeed;
    public static HudManager Instance{get;private set;}
     //placeholder
    
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
        Player = GameObject.FindGameObjectWithTag("Player");
        playerStatus = Player.GetComponent<PlayerStatus>();
        
        textPopDamage = prefabPopDmg.GetComponentInChildren<TMP_Text>();
        fontSizeDefault = textPopDamage.fontSize;
        colorDefault = Color.white;
        impulseForceDefault = impulseForce;
        hpbar.maxValue = playerStatus.maxLife;
    }
    private void Update(){
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryShow();
        }
    }
    public void UpdateInventoryHud(){
        nivelTmp.text = $"{playerStatus.level}";
        nickTmp.text = playerStatus.nick;
        damageTmp.text = $"Base Damage: {playerStatus.damage:f2}";
        lifeTmp.text = $"LifePoints: {playerStatus.currentLife:f2}/{playerStatus.maxLife:f2}";
        speedTmp.text = $"Speed: {playerStatus.speed:f2}";
        atackSpeed.text = $"AtackSpeed: {playerStatus.atackSpeed:f2}";

    }
    public void updateHpBar(){

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
