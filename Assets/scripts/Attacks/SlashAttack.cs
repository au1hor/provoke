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
        progressionHit();
        sound();
      
        for (int i = 0; i < sprites.Length; i++)
        {
            sprRender.sprite = sprites[i];
            yield return new WaitForSeconds(speedAnimation);
        }

        sprRender.enabled = false;
        applyDamage();
        yield return new WaitForSeconds(3);
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
    void progressionHit()
    {
        PlayerAtack playerAtack = player.GetComponent<PlayerAtack>();
        playerAtack.hits += 1;
        atackPitch= 1 * playerAtack.hits;
        if (playerAtack.hits == 5)
        {
            playerAtack.hits = 0;
            atackPitch = 0.75f;
            audioSource.volume = 1;
            this.gameObject.transform.localScale = new Vector3(30,30,10);
            sprRender.color = Color.red;
            CameraManager.Instance.shake();
        }
        
    }
    private void Start() {
       sprRender = this.GetComponent<SpriteRenderer>();
       audioSource = this.GetComponent<AudioSource>();
       StartCoroutine(AnimationDamage());
       

    }
    
}
