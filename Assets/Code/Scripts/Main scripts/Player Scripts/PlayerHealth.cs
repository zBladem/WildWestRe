using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerHealth : MonoBehaviour
{
    public float healthAmount = 100f;    
    public Image HealthBar;
    [HideInInspector] public bool damaged;
    [SerializeField] private TextMeshProUGUI ui;
    Animator ani;
    PlayerMovement player;
    Rigidbody2D rb;
    public new CapsuleCollider2D collider;
    public static event Action PlayerHasDied;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        ani = GetComponent<Animator>();       
    }
    void Start()
    {        
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameController.OnReset += ResetHealth;
        player = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
    }
    private void Update()
    {
        LifeOnUI();
        damaged = false;
    }
    void LifeOnUI()
    {
        healthAmount = Mathf.Clamp(healthAmount, 0, 100f);
        int l = (int)healthAmount;        
        ui.SetText($"{l}%");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Melee enemy = collision.GetComponent<Melee>();
        if (enemy)
        {
            TakeDamage(enemy.damage);
        }
        Hazard hazard = collision.GetComponent<Hazard>();
        if (hazard && hazard.hitDamage > 0)
        {
            TakeDamage(hazard.hitDamage);
        }
        Heal heal = collision.GetComponent<Heal>();
        if (heal)
        {
            Healing(heal.healAmount);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Melee enemy = collision.collider.GetComponent<Melee>();
        if (enemy)
        {
            TakeDamage(enemy.damage);
        }
        Hazard hazard = collision.collider.GetComponent<Hazard>();
        if (hazard && hazard.hitDamage > 0)
        {
            TakeDamage(hazard.hitDamage);
        }
    }
    public void Healing(float heals)
    {
        healthAmount += heals;
        healthAmount = Mathf.Clamp(healthAmount,0,100);
        HealthBar.fillAmount = healthAmount / 100f;       

    }
    public void TakeDamage(float damage)
    {
        spriteRenderer.color = Color.red;
        damaged = true;
        healthAmount -= damage;
        HealthBar.fillAmount = healthAmount / 100f;
        if (healthAmount <= 0)
        {
            LifeOnUI();
            PlayerHasDied?.Invoke();
            ani.SetTrigger("dead");
            player.enabled = false;
            collider.offset = new Vector2(0,-1);
            collider.size = new Vector2((float)0.1, (float)0.1);
            if(player.GroundCheck() == true) rb.bodyType = RigidbodyType2D.Static;
            
        }
        Invoke(nameof(resetsprite), (float)0.1);
    }
    public void resetsprite()
    {
        spriteRenderer.color = Color.white;
    }
    
    public void ResetHealth()    
    {
         
       healthAmount = 100f;       
    }
}