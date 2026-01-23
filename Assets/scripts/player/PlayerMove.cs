using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public void move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.position += (new Vector3(x,y,0) * 3 * Time.deltaTime );
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
}
