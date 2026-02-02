using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
        Char Player;
        Rigidbody2D rb;
        public float moveSpeed;
        public bool isDashing;
    public void move()
    {
        Vector2 inputMove = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;
        transform.position += (Vector3)inputMove * moveSpeed * Time.deltaTime;
        
    }
    IEnumerator Dash()
    {
        isDashing = true;
        Vector3 mouseWord = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWord.z = 0;

        Vector2 dir = (mouseWord - transform.position).normalized;

        float dashTime = 0.10f;
        float dashSpeed = 25f;

        float timer = 0f;
        while(timer < dashTime)
        {
            transform.position += (Vector3)dir * dashSpeed * Time.deltaTime;
            timer += Time.deltaTime;
            yield return null;
        }
        isDashing = false;
    }
   
    void Start()
    {
        Player = FindFirstObjectByType<PlayerStatus>().GetComponent<PlayerStatus>().Player;
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
