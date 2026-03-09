    using System;
using System.Collections;
using System.Diagnostics;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    public GameObject slashSpr;
    public Sprite [] Sprites;
    public AtackPoint atackPoint;
    public float speed = 0.05f;
    public float AtackWeigth;
    public int hits;
    public float atackDamage;
    
    public void Start(){
        if (data.Instance != null)
        {
            atackDamage = data.Instance.Player.damage;
        }else{
            atackDamage = 1;
        }
    }
    public void instanceSprite(Collider2D[] enes)
    {
        foreach (Collider2D ene in enes)
        {   
            if (ene.tag != "Player")
            {
                GameObject Slash = Instantiate(slashSpr,ene.transform.position,quaternion.identity);
                SlashAttack slashAttack =  Slash.GetComponent<SlashAttack>();
                slashAttack.damage =atackDamage;
                slashAttack.sprites = Sprites;
                slashAttack.player = this.gameObject;
                slashAttack.atackPoint = this.atackPoint.gameObject;
                slashAttack.eneColiders = enes;
            }
        }
    }
    public Collider2D[] FindEnemies()
    {
        Collider2D[] enes = atackPoint.CheckEnemies();
        return enes;
    }
    public void Update(){
        if (Input.GetMouseButtonDown(0)){
            instanceSprite(FindEnemies());
        }
    }
}
