using Unity.Mathematics;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    public GameObject prefabPopDmg;
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

    public void PopUpDamage(float damage,GameObject target)
    {
        Vector2 force = new Vector2(UnityEngine.Random.Range(-5f,5),UnityEngine.Random.Range(-5f,5));
        GameObject popDmg = Instantiate(prefabPopDmg,target.transform.position,quaternion.identity);
        popDmg.GetComponent<Rigidbody2D>().AddForce(force,ForceMode2D.Impulse);
        popDmg.GetComponent<PopUp>().textString = damage.ToString();
        Destroy(popDmg,0.3f);
    }
}
