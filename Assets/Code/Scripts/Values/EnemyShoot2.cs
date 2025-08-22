using UnityEngine;

public class EnemyShoot2 : MonoBehaviour
{
    [SerializeField] private Transform Enemy;
    [SerializeField] private float Distance = 5;
    [SerializeField] private LayerMask Target;
    [SerializeField] private bool PlayerRange;
    [SerializeField] private GameObject EnemyBullet;
    [SerializeField] private float TimeBetweenBullet;
    [SerializeField] private float TimeLastBullet;
    [SerializeField] private float BulletCooldown;
    [SerializeField] private Transform Playerr;
    [SerializeField] private Transform Hitbox;
    Animator Animator;
    [SerializeField] private Transform bulletspaw;
    [SerializeField] private AudioClip audio;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }
    private void Update()
    {
        PlayerRange = Physics2D.OverlapBox(Hitbox.position, new Vector2(Distance, Distance), 0, Target);

        if (PlayerRange)
        {
            if (Time.time > TimeBetweenBullet + TimeLastBullet)
            {
                
                TimeLastBullet = Time.time;
                float randomValue = Random.value;

                Invoke(nameof(Shoot1), BulletCooldown);

            }
        }
    }
    private void Shoot1()
    {
        Animator.SetBool("shoot", true);
        Vector3 direction = (Playerr.position - Enemy.position).normalized;

        soundscontroller.Instance.EjecutarSonido(audio);
        GameObject bullet = Instantiate(EnemyBullet, Enemy.position, Quaternion.identity);
        bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        Invoke(nameof(ResetTT), (float)0.5);    
    }
    private void ResetTT()
    {
        Animator.SetBool("shoot", false);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Hitbox.position, new Vector3(Distance, Distance, 0));
        Gizmos.DrawLine(Enemy.position, Playerr.position);/* + (Enemy.position - Playerr.position).normalized)*/
    }
}