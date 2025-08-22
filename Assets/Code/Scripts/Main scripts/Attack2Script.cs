using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2Script : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private int bulletCount = 8;
    [SerializeField] private float bulletSpeed = 5f;
    private void Update()
    {
        PerformAttack();
    }
    public void PerformAttack()
    {
        float angleStep = 360f / bulletCount;
        float angle = 0f;

        for (int i = 0; i < bulletCount; i++)
        {
            float bulletDirX = attackPoint.position.x - 45;
            float bulletDirY = attackPoint.position.y - 45;

            Vector3 bulletVector = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector3 bulletMoveDirection = (bulletVector - attackPoint.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
            BulletBossATTACK bossBullet = bullet.GetComponent<BulletBossATTACK>();
            if (bossBullet != null)
            {
                bossBullet.SetDirection(bulletMoveDirection);
                bossBullet.SetSpeed(bulletSpeed);
            }

            angle += angleStep;
        }
    }
}