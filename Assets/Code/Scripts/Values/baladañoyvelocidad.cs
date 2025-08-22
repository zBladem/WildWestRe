using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float velocidad;
    public int daño;
    private Vector2 direccion;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    public void SetDirection(Vector2 direction)
    {
        direccion = direction;
    }

    private void Update()
    {
        //Vector3 pos = transform.position;
        //pos.y = 0;
        //transform.position = pos;
        //Vector3 scl = transform.localScale;
        //scl.x = direccion.x > 0 ? 1 : -1;
     //   transform.localScale = scl;
        rb2d.velocity=direccion * velocidad ;
        transform.right = direccion;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerHealth vidajugador))
        {
            vidajugador.TakeDamage(daño);
            Destroy(gameObject); 
        }
    }
}
