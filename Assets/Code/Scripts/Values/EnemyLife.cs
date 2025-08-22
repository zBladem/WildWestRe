using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float life;

    public void EnemyTakeDamage(float value)
    {
        life += value;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bala"))
        {
            Destroy(collision.gameObject);
            EnemyTakeDamage(-1);

        }
    } 
 
}
