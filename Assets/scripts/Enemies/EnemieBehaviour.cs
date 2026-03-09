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
        StateChange(States.getDamage);
    }
    IEnumerator HitEffect(float damage)
    {
        Debug.Log("AIAIAI");
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
        if (estado == state)return;
        state = estado;
        switch(estado){
            default:
                sprite.color = Color.white;
                textAnimaton($"<color=green>Chilling");
            break;
            case States.getDamage:
                    sprite.color = Color.blue;
                    textAnimaton($"<color=blue>HItted");
            break;
            case States.chase:
                sprite.color = Color.orange;
                textAnimaton($"<color=orange>Chasinng");
            break;
            case States.attack:
                sprite.color = Color.darkRed;
                textAnimaton($"<color=red>Atacking");
            break;
        }
    }
    Coroutine textAnim;
    public void textAnimaton(string texto){
        if(textAnim != null){
            StopCoroutine(textAnim);
            Debug.Log("cooritina paradinha");
        }
        textAnim = StartCoroutine(TextAnimation(texto));
        

    }
    IEnumerator TextAnimation(string Texto){
         Debug.Log("Coroutine started");
        while (true)
        {
        StateText.text = Texto;
        yield return new WaitForSeconds(0.3f);
        StateText.text += ".";
        yield return new WaitForSeconds(0.3f);
        StateText.text += ".";
        yield return new WaitForSeconds(0.3f);
        StateText.text += ".";
        yield return new WaitForSeconds(0.3f);
       
        }
        
    }
    public void Update(){
        distance = (this.transform.position - player.transform.position).magnitude;

        if (distance <= rangeAttack && hit == null )
        {
            StateChange(States.attack);
        }
        else if(distance <= rangeChase && hit == null)
        {
            StateChange(States.chase);  
            this.transform.position = Vector3.MoveTowards(transform.position,player.transform.position,speed * Time.deltaTime);
        }else if(hit == null){
            StateChange(States.chilling);
        }
    }
}
