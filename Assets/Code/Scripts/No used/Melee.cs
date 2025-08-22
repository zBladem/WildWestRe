using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public float damage;
    [SerializeField] private Transform player;
    [SerializeField] private PlayerMovement playermovement;
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform Hitbox;
    [SerializeField] private float Distance = 5;
    [SerializeField] private LayerMask Target;
    [SerializeField] private Vector2 size;
    public float TimeBetweenAttack;
    public float TimeLastAttack;
    public float AttackCooldown;
    Animator animator;

    private bool PlayerRange;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        PlayerRange = Physics2D.OverlapBox(Hitbox.position, new Vector2(Distance, Distance), 0, Target);
        if (PlayerRange)
        {
            if (Time.time > TimeBetweenAttack + TimeLastAttack)
            {
                animator.SetBool("punch", true);
                TimeLastAttack = Time.time;
                Invoke(nameof(Attack), AttackCooldown);
                Invoke(nameof(Resetboll), (float)0.5);
            }
        }
    }
    private void Resetboll()
    {
        animator.SetBool("punch", false);   
    }
    private void Attack() {
    
        Collider2D[] objects = Physics2D.OverlapBoxAll(Hitbox.position,size,0);

        foreach(Collider2D collider in objects)
        {
            if(collider.CompareTag("Player"))
            {
                
                collider.transform.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Hitbox.position, size);

    }
}
