using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    [SerializeField] private float maxBounceHeight = 2f; // altura máxima del rebote
    [SerializeField] private int health = 3;             // vida de la bomba (para balas)
    [SerializeField] private int damage = 1;             // daño al jugador

    private Rigidbody2D rb;
    private Vector2 spawnPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPos = transform.position;
    }

    private void FixedUpdate()
    {
        // Limitar altura máxima respecto al spawn
        if (transform.position.y - spawnPos.y > maxBounceHeight && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // corta la subida
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si choca con el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aquí llamas a tu script de vida del jugador
            // collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);

            Destroy(gameObject); // la bomba se destruye al explotar
        }

        // Si choca con una bala
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
            Destroy(collision.gameObject); // destruye la bala que lo golpeó

            if (health <= 0)
            {
                Destroy(gameObject); // la bomba muere si su vida llega a 0
            }
        }
    }
}