using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;

public class PlayerAtack : MonoBehaviour
{
    public GameObject slashSpr;
    public Sprite [] Sprites;
    public AtackPoint atackPoint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void instanceSprite()
    {
        GameObject Slash = Instantiate(slashSpr,atackPoint.transform.position,quaternion.identity);
        StartCoroutine(SlashAnimation(Slash));
    }
    public void rotacion(GameObject obj)
    {
        Vector3 dir = (atackPoint.transform.position - atackPoint.player.transform.position).normalized;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        obj.transform.rotation = Quaternion.Euler(0,0,angle - 90f);
    }
    IEnumerator SlashAnimation(GameObject Slash)
    {
        SpriteRenderer sr = Slash.GetComponent<SpriteRenderer>();
        for (int i = 0; i < Sprites.Length; i++)
        {
            sr.sprite = Sprites[i];
            rotacion(Slash);
             yield return new WaitForSeconds(0.1f);
        }
        
        Destroy(Slash);
        
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            instanceSprite();
        }
    }
}
