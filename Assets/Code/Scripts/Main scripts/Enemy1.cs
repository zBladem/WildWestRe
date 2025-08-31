using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [Header("Basic Config")]
    public Transform position;          // punto de referencia para patrullar
    [SerializeField] private float speed = 2f;
    [SerializeField] private Vector2 direction = Vector2.right;
    private float timer;
    [SerializeField] private float maxTimer = 3f;
    private Rigidbody2D rb2d;

    [Header("Animación")]
    public Animator animator; // asignar en Inspector

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (animator == null) animator = GetComponent<Animator>();
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
                transform.localScale = new Vector3(direction.x, 1, 1);
                timer = 0;
            }
        }

        rb2d.velocity = new Vector2(direction.x * speed, rb2d.velocity.y);
    }
}