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
    public float AtackWeigth;
    public int hits;
    public float atackDamage;
    
    
    public void instanceSprite(Collider2D colider,Collider2D[] enes)
    {
       GameObject Slash = Instantiate(slashSpr,colider.transform.position,quaternion.identity);
       SlashAttack slashAttack =  Slash.GetComponent<SlashAttack>();
       slashAttack.damage =12;
       slashAttack.sprites = Sprites;
       slashAttack.player = this.gameObject;
       slashAttack.atackPoint = this.atackPoint.gameObject;
       slashAttack.eneColiders = enes;
    }
    public void FindEnemies()
    {
        Collider2D[] enes = atackPoint.CheckEnemies();
        foreach (Collider2D ene in enes)
        {
            instanceSprite(ene,enes);
        }
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            FindEnemies(); 

        }
    }
}
