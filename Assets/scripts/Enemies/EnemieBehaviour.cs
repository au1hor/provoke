using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemieBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float life = 100;
    public float speed;
    public float rangeAttack;
    public float rangeChase;
    public Transform player;
    public float knockBack = 3f;
    public float duration = 0.05f;
    public States state;
    public float distance;
    public enum States{
        getDamage,
        chilling,
        chase,
        attack
    }
    public TMP_Text StateText;
    public SpriteRenderer sprite;
    
    Coroutine hit ;

    public void GetDamage(float damage)
    {
        life -= 1;
        if (hit != null)
        {
            StopCoroutine(hit);
        }
        hit = StartCoroutine(HitEffect(damage));
        state = States.getDamage;
    }
    IEnumerator HitEffect(float damage)
    {
        float timer = 0;
        Vector3 startpos = transform.position;
        Vector3 dir = (transform.position- player.position).normalized;
        Vector3 targePos = startpos +dir * knockBack;
        while (timer <duration)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(startpos,targePos,timer/duration);
            yield return null;
        }
        HudManager.Instance.PopUpDamage(damage,this.gameObject);
        yield return new WaitForSeconds(0.05f);
        hit = null;
    }
    public void StateChange(States estado){
        switch(estado){
            default:
                sprite.color = Color.white;
                StateText.text = $"<color=green>chilling...</color> ";
            break;
            case States.getDamage:
                    sprite.color = Color.white;
                    StateText.text = $"<color=blue>HITted</color> ";
            break;
            case States.chase:
                this.transform.position = Vector3.MoveTowards(transform.position,player.transform.position,speed * Time.deltaTime);
                sprite.color = Color.orange;
                StateText.text = $"<color=orange>Chasinng...</color> ";
            break;
            case States.attack:
                sprite.color = Color.darkRed;
                StateText.text = $"<color=red>Atacking</color>";
            break;
        }
    }
    public void PopUpState(){}
    public void Update(){
        distance = (this.transform.position - player.transform.position).magnitude;
        if (hit!= null)
        {
            StateChange(States.getDamage);
        }
        else if (distance <= rangeAttack )
        {
            StateChange(States.attack);
        }
        else if(distance <= rangeChase)
        {
            StateChange(States.chase);  
        }else {
            StateChange(States.chilling);
        }
    }
}
