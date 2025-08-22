using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2d;
    public PlayerMovement movement;
    
    [Header("Shoot config")]    
    public GameObject bulletPrefab;
    public Transform firePoint;
    [SerializeField] private float fireRate = 0.5f;    
    [SerializeField] private float bulletsSpeed = 10f;
    [SerializeField] private float bulletDestroyTime = 2f;   
    [SerializeField] private float bulletCooldown = 3f;
    [SerializeField] Vector2 firePointLocation = new(5f, 5f);
    [SerializeField] AudioClip bulletSound;

    bool shooting;
    private float timeBulletCooldown;
    void Start()
    {  
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
               if (timeBulletCooldown > 0)
        {
            shooting = false;
            timeBulletCooldown -= Time.deltaTime;            
        }

    }


    #region Shoot
    public void Shoot(InputAction.CallbackContext context)
    {
       
        if (context.performed  && timeBulletCooldown <= 0)
        {
            soundscontroller.Instance.EjecutarSonido(bulletSound);
            animator.SetTrigger("shoot");
            shooting = true;
            Fire();
            timeBulletCooldown = bulletCooldown;
            
        }
    }
   private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direccion = mouse - (Vector2)transform.position;        

        //bullet.transform.rotation = Quaternion.identity;
        bullet.transform.right = direccion.normalized;
        

         //Vector2 shootDirection = transform.localScale;
        //bullet.transform.localScale = shootDirection.normalized;
            if (rb != null)
        {
            //rb.velocity = shootDirection * bulletsSpeed;
            rb.velocity = direccion.normalized * bulletsSpeed;
        }
       
        
        
        
    }

    #endregion
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(firePoint.position, firePointLocation);
    }

}
