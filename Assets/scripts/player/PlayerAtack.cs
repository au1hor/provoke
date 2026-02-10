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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void instanceSprite()
    {
        GameObject Slash = Instantiate(slashSpr,atackPoint.transform.position,quaternion.identity);
        StartCoroutine(SlashAnimation(Slash));
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
        As.pitch = UnityEngine.Random.Range(1f,2.1f);
        As.Play();
        Destroy(As,As.clip.length);
    }
    IEnumerator SlashAnimation(GameObject Slash)
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
        
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            instanceSprite();
        }
    }
}
