using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemieBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float life = 100;
    public float speed;
    public Transform player;
    public float knockBack = 3f;
    public float duration = 0.05f;
    public States state;
    public float distance;
    public enum States{
        chilling,
        chase,
        attack
    }
    public TMP_Text StateText;
    public SpriteRenderer sprite;
    
    Coroutine hit ;

    public void getDamage(float damage)
    {
        life -= 1;
        if (hit != null)
        {
            StopCoroutine(hit);
        }
        hit = StartCoroutine(HitEffect(damage));
    }
    IEnumerator HitEffect(float damage)
    {
        float timer = 0;
        Vector3 startpos = transform.position;
        Vector3 dir = (transform.position- player.position).normalized;
        Vector3 targePos = startpos +dir * knockBack;
        this.GetComponent<SpriteRenderer>().color = Color.white;
        while (timer <duration)
        {
            timer += Time.deltaTime;
           transform.position = Vector3.Lerp(startpos,targePos,timer/duration);
             yield return null;
        }
         this.GetComponent<SpriteRenderer>().color = Color.red;
         hit = null;
         HudManager.Instance.PopUpDamage(damage,this.gameObject);
    }
    public void stateChange(States estado){
        switch(estado){
            default:
                Debug.Log("chilling");
                sprite.color = Color.white;
                StateText.text = $"<color=green>chilling...</color> ";
            break;
            case States.chase:
                Debug.Log("Chasing");
                this.transform.position = Vector3.MoveTowards(transform.position,player.transform.position,speed * Time.deltaTime);
                sprite.color = Color.red;
                StateText.text = $"<color=orange>Chasinng...</color> ";
            break;
            case States.attack:
                Debug.Log("Attacking");
            break;
        }
    }
    public void popUpState(){}
    public void Update(){
        distance = (this.transform.position - player.transform.position).magnitude;
        if (distance <= 10)
        {
            stateChange(States.chase);  
        }else {
            stateChange(States.chilling);
        }
    }
}
