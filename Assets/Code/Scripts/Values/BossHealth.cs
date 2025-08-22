using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public float life;

    public void EnemyTakeDamage(float value)
    {
        life += value;
        if (life <= 0)
        {
            SceneManager.LoadScene(sceneName);
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
        