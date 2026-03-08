using Unity.VisualScripting;
using UnityEngine;

public class EnemieAtack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void SearchForEnemies(){
        RaycastHit2D[] enemies = Physics2D.CircleCastAll(transform.position,3f,Vector2.one);
        foreach (RaycastHit2D col in enemies)
        {
            if (col.collider.gameObject.tag == "Player")
            {
                Debug.Log("PlayerEncontrado");
            }
            
        }
    }
    public void Update(){
        SearchForEnemies();
    
    }
}
