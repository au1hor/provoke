using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
        Rigidbody2D rb;
        public float moveSpeed;
        public bool isDashing;
        Vector2 inputMove;
        public float dashTime = 0.10f;
        public float dashSpeed = 55f;   
    public void move()
    {
        inputMove = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;
        transform.position += (Vector3)inputMove * moveSpeed * Time.deltaTime;
        
    }
    IEnumerator Dash()
    {
        isDashing = true;
        float timer = 0f;
        while(timer < dashTime)
        {
            transform.position += (Vector3)inputMove.normalized * dashSpeed * Time.deltaTime;
            timer += Time.deltaTime;
             yield return null;
         
        }
        isDashing = false;
    }
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDashing)
        {
           move(); 
        }
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            StartCoroutine(Dash());
        }
        
    }
}
