using UnityEngine;

public class PlayerMove : MonoBehaviour
{
        Char Player;
        Rigidbody2D rb;
    public void move()
    {
         float cd = 0;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.position += new Vector3(x,y,0)  * Player.moveSpeed * Time.deltaTime ;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
           
            if (y != 0)
            {
                rb.linearVelocity = new Vector2(0,10);
                cd = 3;
            }
            else
            {
                 rb.linearVelocity = new Vector2(10,0);
                 cd = 3;
            }
            
            Debug.Log("Dash");
        }
        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
   
    void Start()
    {
        Player = FindFirstObjectByType<PlayerStatus>().GetComponent<PlayerStatus>().Player;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        Debug.Log(Player.moveSpeed);
    }
}
