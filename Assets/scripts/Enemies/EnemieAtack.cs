using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class EnemieAtack : MonoBehaviour
{
    public EnemieBehaviour behaviour;
    public void Start(){
        behaviour = this.gameObject.GetComponent<EnemieBehaviour>();
    }
    public void SearchForEnemies(){
        RaycastHit2D[] enemies = Physics2D.CircleCastAll(transform.position,10f,Vector2.one);
        foreach (RaycastHit2D col in enemies)
        {
            if (col.collider.gameObject.tag == "Player")
            {
                Debug.Log("PlayerEncontrado");
                var distance = (transform.position - col.collider.gameObject.transform.position);
                behaviour.state = EnemieBehaviour.States.chase;
            }
        }
    }

    public void Update(){

    }
}
