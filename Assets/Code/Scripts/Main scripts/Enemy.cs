using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Basic Config")]
    public Transform position;       
    [SerializeField] private float speed;
    [SerializeField] private Vector2 direction;
    private float timer;
    [SerializeField] private float maxTimer;
    private Rigidbody2D rb2d;
          

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();                
    } 
    void Move()
    {
        if (position)
        {
            timer += Time.deltaTime;
            if (timer > maxTimer)
            {
                direction *= -1;
                transform.localScale = new Vector3(direction.x,1,1)*1.6f;
                timer = 0;
            }
        }
        rb2d.velocity = new Vector2(direction.x * speed, rb2d.velocity.y);
    }
    
}
