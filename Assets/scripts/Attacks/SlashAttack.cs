using System.Collections;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SlashAttack : MonoBehaviour
{
   public GameObject player;
   public GameObject atackPoint;
   public float speedAnimation;
   public Sprite [] sprites;
   public SpriteRenderer sprRender;
   public AudioSource audioSource;
   public Collider2D [] eneColiders;
   //stats
   public float damage;
   //som
   public float atackPitch;

   public Vector2 size = new Vector2(5f,5f);
   
   IEnumerator AnimationDamage()
    {
        rotation();
        progressionHit();
        sound();
        applyDamage();
      
        for (int i = 0; i < sprites.Length; i++)
        {
            sprRender.sprite = sprites[i];
            yield return new WaitForSeconds(speedAnimation);
        }

        sprRender.enabled = false;
        
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
            ene.GetComponent<EnemieTest>().getDamage(damage);
        }
    }
    void progressionHit()
    {
        HudManager.Instance.resetToNormalHIt();
        PlayerAtack playerAtack = player.GetComponent<PlayerAtack>();
        playerAtack.hits += 1;
        damage *= playerAtack.hits;
        atackPitch= Mathf.Max(0.1f * playerAtack.hits,0.7f);
        Debug.Log(atackPitch);
        if (playerAtack.hits == 22)
        {
            playerAtack.hits = 0;
            damage *= 100000;
            atackPitch = 0.75f;
            audioSource.volume = 1;
            HudManager.Instance.EspecialHit(Color.red,90);
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
