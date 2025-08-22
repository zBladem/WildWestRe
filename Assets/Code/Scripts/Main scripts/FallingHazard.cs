using UnityEngine;

public class FallingHazard : MonoBehaviour
{
    public float AreaDeDeteccion = 5f;
    public string AvisoDeCaida = "AnimacionDeCaida";
    private Rigidbody2D rb;
    public bool Istrigger = false;
    private Animator animator;
    public Transform Player;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!Istrigger)
        {
            float Distancia = Vector2.Distance(Player.position, transform.position);
            if (Distancia <= AreaDeDeteccion)
            {
                Istrigger = true;
                animator.Play(AvisoDeCaida);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    public void Caida()
    {
        animator.enabled = false;
        rb.gravityScale = 1f;
    }

    

    private void OnDrawGizmos()
    {
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, AreaDeDeteccion);
    }
}

