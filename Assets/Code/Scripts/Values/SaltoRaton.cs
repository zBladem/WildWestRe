using UnityEngine;

public class SaltoRaton : MonoBehaviour
{
    [SerializeField] private Transform Enemy;
    [SerializeField] private float distancialinea = 10;
    [SerializeField] private LayerMask player;
    [SerializeField] private float JumpForce = 10f;
    [SerializeField] private Rigidbody2D rb2d;


    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private Vector2 groundCheckSize;

    [SerializeField] private float cooldownjump = 2;

    public bool isGrounded;


    private void GroundCheck()
    {
        if (Physics2D.OverlapBox(groundcheck.position, groundCheckSize, 0, ground))
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }
    }


    private void Update()
    {
        GroundCheck();
        cooldownjump -= Time.deltaTime;


    }

    private void Saltar()
    {
        
            rb2d.velocity = new Vector2(rb2d.velocity.x, JumpForce);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundcheck.position,groundCheckSize);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (isGrounded && collision.gameObject.CompareTag("bala") && cooldownjump <= 0)

        {

            Saltar();
            cooldownjump = 5f;

        }
    }
}
