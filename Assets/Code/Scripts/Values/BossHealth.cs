using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public float life = 10f;
    public float maxLife = 10f;

    [Header("UI")]
    [SerializeField] private Transform bossBar; // el objeto visual de la barra

    public void EnemyTakeDamage(float value)
    {
        life += value;

        // Actualizamos la barra
        UpdateBossBar();

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

    private void UpdateBossBar()
    {
        if (bossBar != null)
        {
            bossBar.transform.localScale = new Vector3(Mathf.Clamp01(life / maxLife), 1f, 1f);
        }
    }
}