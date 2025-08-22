 using System.Collections;
using UnityEngine;

public class CaerPlataforma : MonoBehaviour
{
    [SerializeField] private float Tiempo;
    [SerializeField] private float GravedadAlCaer;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Caer(other));
        }
    }

    private IEnumerator Caer(Collision2D other)
    {
        yield return new WaitForSeconds(Tiempo);        

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.collider);

        rb2d.constraints = RigidbodyConstraints2D.None;

        rb2d.gravityScale = GravedadAlCaer;

        rb2d.AddForce(new Vector2(0, -10f)); 
    }
}