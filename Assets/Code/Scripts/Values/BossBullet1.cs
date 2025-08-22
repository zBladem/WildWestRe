using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet1 : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    [Header("Bullet")]

    [SerializeField] float speed = 7;
    [SerializeField] float damage = 15;
    [SerializeField] float despawnTimer = 6;
    [SerializeField] Vector2 size;
    private float currentDespawnTimer;
    private void Awake()
    {
        currentDespawnTimer = despawnTimer;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector2 direction = player.transform.position - transform.position;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
    }
    void Update()
    {
        currentDespawnTimer -= Time.deltaTime;
        if (currentDespawnTimer <= 0)
        {
            Destroy(gameObject);
        }
        Damage();
    }

    private void Damage()
    {
        Collider2D[] objects = Physics2D.OverlapBoxAll(transform.position, size, 0);
        foreach (Collider2D collider in objects)
        {
            if (collider.CompareTag("Player"))
            {
                collider.transform.GetComponent<PlayerHealth>().TakeDamage(damage);
                Destroy(gameObject);
            }
            else if (collider.CompareTag("enemy"))
            {

            }
            else
            {
                Destroy(gameObject);
            }

        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
