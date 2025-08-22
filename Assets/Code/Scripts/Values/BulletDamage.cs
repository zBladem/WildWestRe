using UnityEngine;
using UnityEngine.InputSystem;

public class BulletDamage : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public int Damage = 1;
    public float speed = 2;
    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        //rb2d.velocity = new(rb2d.velocity.x, rb2d.velocity.y);
        Destroy((this.gameObject), 5);
        
    }    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BossHealth bossHealth = collision.GetComponent<BossHealth>();
        if (bossHealth)
        {
            bossHealth.EnemyTakeDamage(Damage);
            Destroy(gameObject);
        }
        EnemyLife enemy = collision.GetComponent<EnemyLife>();
        if (enemy)
        {
            enemy.EnemyTakeDamage(Damage);

            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
       
    }
}
