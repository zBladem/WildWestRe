using UnityEngine;

public class Attack1Script : MonoBehaviour
{
    [SerializeField] Transform bulletPrefab;
    private Transform player;
    [SerializeField] float delay = 1;
    [SerializeField] float repeatingTime = 0.5f;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnEnable()
    {
        InvokeRepeating(nameof(Shoot), delay, repeatingTime);   
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    private void Shoot()
    {
        Vector2 dir = player.position - transform.position;
        dir *= -1f;

        Transform r = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        r.transform.up = dir;
    }
}
