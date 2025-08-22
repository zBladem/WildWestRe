using System;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public float healAmount = 1;
    PlayerHealth health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject,(float)0.1);
        }
    }
}
