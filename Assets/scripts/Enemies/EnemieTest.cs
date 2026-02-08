using System.Collections;
using UnityEngine;

public class EnemieTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float life = 100;
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
    public void getDamage()
    {
        life -= 1;
        StartCoroutine(HitEffect());
    }
    IEnumerator HitEffect()
    {
        float timer = 0;
        while (timer < 0.1)
        {
            timer += Time.deltaTime;
            this.GetComponent<SpriteRenderer>().color = Color.white;
             yield return null;

        }
         this.GetComponent<SpriteRenderer>().color = Color.red;
       
    }
}
