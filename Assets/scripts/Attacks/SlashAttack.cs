using System.Collections;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class SlashAttack : MonoBehaviour
{
   public GameObject player;
   public GameObject atackPoint;
   public float speedAnimation;
   public Sprite [] sprites;
   public SpriteRenderer sprRender;
   public AudioSource audioSource;
   public Collider2D [] eneColiders;
   //som
   public float atackPitch;

   public Vector2 size = new Vector2(5f,5f);
   
   IEnumerator AnimationDamage()
    {
        rotation();
        sound();
        player.GetComponent<PlayerAtack>().hits += 1;
        for (int i = 0; i < sprites.Length; i++)
        {
            sprRender.sprite = sprites[i];
            yield return new WaitForSeconds(speedAnimation);
        }

        sprRender.enabled = false;
        applyDamage();
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
    void rotation()
    {
        float x = UnityEngine.Random.Range(-90,90);
        float y = UnityEngine.Random.Range(-90,90);
        float angle = Mathf.Atan2(x,y) * Mathf.Rad2Deg;
        transform.rotation = quaternion.Euler(0,0,angle -90);
    }
    void sound()
    {
        audioSource.pitch = atackPitch;
        audioSource.Play();
    }
    void applyDamage()
    {
        foreach (Collider2D ene in eneColiders)
        {
            ene.GetComponent<EnemieTest>().getDamage();
            
        }
    }
    private void Start() {
       sprRender = this.GetComponent<SpriteRenderer>();
       audioSource = this.GetComponent<AudioSource>();
       StartCoroutine(AnimationDamage());
       

    }
    
}
