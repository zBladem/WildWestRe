using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float repulse = 20f;
    public float hitDamage = 1;   
    public PlayerHealth Player;
    public Vector2 diagonal;



    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Player = collision.collider.GetComponent<PlayerHealth>();
    //    Rigidbody2D r = collision.rigidbody;
    //    r.AddForce(-collision.contacts[0].normal * repulse, ForceMode2D.Impulse);
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerRepulsed(collision.gameObject, diagonal);
        }
    }
    private void PlayerRepulsed(GameObject player, Vector2 repulse)
    {
        Rigidbody2D rb2d = player.GetComponent<Rigidbody2D>();
        if (rb2d)
        {
            rb2d.velocity = Vector2.zero;


            rb2d.AddForce(repulse, ForceMode2D.Impulse);
        }
    }
}
