using System.Collections;
using UnityEngine;

public class EnemieTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float life = 100;
    public Transform Player;
     public float knockBack = 3f;
    public float duration = 0.05f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            getDamage();
        }
    }
    Coroutine hit ;
    public void getDamage()
    {
        life -= 1;
        if (hit != null)
        {
            StopCoroutine(hit);
        }
        hit = StartCoroutine(HitEffect());
    }
    IEnumerator HitEffect()
    {
        float timer = 0;
       
        Vector3 startpos = transform.position;
        Vector3 dir = (transform.position- Player.position).normalized;
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
       
    }
}
