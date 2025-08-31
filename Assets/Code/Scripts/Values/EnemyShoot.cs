using UnityEngine;

public class EnemyShoot1 : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    [Header("Puntos de Disparo")]
    [SerializeField] private Transform Enemy;   // centro
    [SerializeField] private Transform Enemy1;
    [SerializeField] private Transform Enemy2;
    [SerializeField] private Transform Enemy3;

    [Header("Detección del Player")]
    public float Distance = 5;
    [SerializeField] private LayerMask Target;
    [SerializeField] private Transform Playerr;
    [SerializeField] private Transform Hitbox;

    [Header("Prefabs")]
    [SerializeField] private GameObject EnemyBullet;
    [SerializeField] private GameObject attack2Prefab;

    [Header("Ataque 2")]
    [SerializeField] private Transform attack2SpawnPoint;

    [Header("Cooldowns")]
    [SerializeField] private float attackCooldown = 2f;
    private float lastAttackTime;
    [SerializeField] private float BulletDelay = 0.3f;

    [Header("Referencias")]
    [SerializeField] private Animator animator; // para triggers de ataque
    [SerializeField] private Enemy1 enemyMovement; // referencia al script de movimiento

    private bool PlayerRange;

    private void Update()
    {
        PlayerRange = Physics2D.OverlapBox(
            Hitbox.position,
            new Vector2(Distance, Distance),
            0,
            Target
        );

        if (PlayerRange && Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;
            float randomValue = Random.value;

            if (randomValue < 0.5f)
            {
                // Ataque triple
                animator.SetTrigger("Attack1");
                Invoke(nameof(Shoot2), BulletDelay);
            }
            else
            {
                // Ataque especial
                animator.SetTrigger("Attack2");
                Invoke(nameof(Attack2), BulletDelay);
            }

            if (audioClip != null)
                soundscontroller.Instance.EjecutarSonido(audioClip);
        }
    }

    private void Shoot2()
    {
        Vector3 direction = (Playerr.position - Enemy.position).normalized;

        GameObject bullet = Instantiate(EnemyBullet, Enemy1.position, Quaternion.identity);
        GameObject bullet1 = Instantiate(EnemyBullet, Enemy2.position, Quaternion.identity);
        GameObject bullet2 = Instantiate(EnemyBullet, Enemy3.position, Quaternion.identity);

        bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        bullet1.GetComponent<EnemyBullet>().SetDirection(direction);
        bullet2.GetComponent<EnemyBullet>().SetDirection(direction);
    }

    private void Attack2()
    {
        Vector3 direction = (Playerr.position - Enemy.position).normalized;

        GameObject bull = Instantiate(attack2Prefab, attack2SpawnPoint.position, Quaternion.identity);
        bull.GetComponent<EnemyBullet>().SetDirection(direction);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Hitbox.position, new Vector3(Distance, Distance, 0));
        if (Enemy != null && Playerr != null)
            Gizmos.DrawLine(Enemy.position, Playerr.position);
    }
}