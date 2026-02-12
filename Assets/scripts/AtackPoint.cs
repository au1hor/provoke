using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AtackPoint : MonoBehaviour
{
    public GameObject player;
    public float distance = 1.5f;
    public float minDistance = 1.5f;
    void Start()
    {
    }
    public void AtackIndicatorMove()
    {
         Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 rawDir = mousePosition - player.transform.position;
        float mouseDistance = rawDir.magnitude;
        float finalDistance = math.clamp(mouseDistance,minDistance,distance);
        Vector3 dir = rawDir.normalized;
        transform.position = player.transform.position + dir * finalDistance;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle - 90f);
    }
    public Collider2D[] CheckEnemies()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position,new Vector2(10,10),0f);
       return hits;
    }
    void Update()
    {
       AtackIndicatorMove();
    }
}
