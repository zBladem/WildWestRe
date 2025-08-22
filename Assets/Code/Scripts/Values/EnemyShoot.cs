using UnityEngine;

public class EnemyShoot1 : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] private Transform Enemy;
    [SerializeField] private Transform Enemy1;
    [SerializeField] private Transform Enemy2;
    [SerializeField] private Transform Enemy3;
    public float Distance = 5;
    [SerializeField] private LayerMask Target;
    public bool PlayerRange;
    [SerializeField] private GameObject EnemyBullet;
    [SerializeField] private float TimeBetweenBullet;
    [SerializeField] private float TimeLastBullet;
    [SerializeField] private float BulletCooldown;
    [SerializeField] private Transform Playerr;
    [SerializeField] private Transform Hitbox;
    private void Update()
    {
        PlayerRange = Physics2D.OverlapBox(Hitbox.position, new Vector2(Distance, Distance), 0, Target); 

        if (PlayerRange)
        {
            if (Time.time > TimeBetweenBullet + TimeLastBullet)
            {
                TimeLastBullet = Time.time;
                float randomValue = Random.value;
                if (randomValue < 0.33f)
                {
                    Invoke(nameof(Shoot1), BulletCooldown);
                    soundscontroller.Instance.EjecutarSonido(audioClip);

                }
                else if (randomValue < 0.66)
                {   
                    Invoke(nameof(Shoot2), BulletCooldown);
                    soundscontroller.Instance.EjecutarSonido(audioClip);


                }
            }
        }
    }
    private void Shoot1()
    {
        Vector3 direction = (Playerr.position - Enemy.position).normalized;

        GameObject bullet = Instantiate(EnemyBullet, Enemy.position, Quaternion.identity);
        bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        

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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Hitbox.position, new Vector3(Distance, Distance, 0));
        Gizmos.DrawLine(Enemy.position, Playerr.position);/* + (Enemy.position - Playerr.position).normalized)*/
    }
}