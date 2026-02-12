    using System;
using System.Collections;
using System.Diagnostics;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    public GameObject slashSpr;
    public Sprite [] Sprites;
    public AtackPoint atackPoint;
    public float speed = 0.05f;
    float AtackWeigth;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void instanceSprite(Collider2D colider)
    {
        GameObject Slash = Instantiate(slashSpr,colider.transform.position,quaternion.identity);
        StartCoroutine(SlashAnimation(Slash,colider));
    }
    public void rotacion(GameObject obj)
    {   UnityEngine.Random.Range(0,10);
        Vector3 dir = (atackPoint.transform.position - atackPoint.player.transform.position).normalized;
        float angle = Mathf.Atan2(UnityEngine.Random.Range(-90,90),UnityEngine.Random.Range(-90,90)) * Mathf.Rad2Deg;
        obj.transform.rotation = Quaternion.Euler(0,0,angle - 90f);
    }
    public void soundEffect(GameObject obj)
    {
        AudioSource As = obj.GetComponent<AudioSource>();
        As.volume = 0.28f;
        if (AtackWeigth < 3)
        {
            AtackWeigth += 0.25f;
        }else
        {
            As.volume =0.5f;
            AtackWeigth = 1;
            obj.gameObject.transform.localScale = new Vector3(10,10,10);
            CameraManager.Instance.shake();

        }
        As.pitch = AtackWeigth;
        As.Play();
        Destroy(As,As.clip.length);
    }
    IEnumerator SlashAnimation(GameObject Slash,Collider2D colider)
    {
        SpriteRenderer sr = Slash.GetComponent<SpriteRenderer>();
        rotacion(Slash);    
        soundEffect(Slash);
        for (int i = 0; i < Sprites.Length; i++)
        {
            sr.sprite = Sprites[i];
            
             yield return new WaitForSeconds(speed);
        }
        sr.enabled = false;
       yield return new WaitForSeconds(0.05f);
       colider.GetComponent<EnemieTest>().getDamage();
       yield return new WaitForSeconds(0.7f);
       Destroy(Slash);
        
        
    }
    public void DamageToEnemies()
    {
        Collider2D[] enes = atackPoint.CheckEnemies();
        foreach (Collider2D ene in enes)
        {   instanceSprite(ene);
            

        }
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            DamageToEnemies(); 

        }
    }
}
