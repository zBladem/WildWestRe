using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Rigidbody2D rb2d;
    private CapsuleCollider2D collider;
    private Animator animator;

    [Header("Dash Config")]
    [SerializeField] float dashSpeed = 15f;
    [SerializeField] float dashDuration = 0.5f;
    [SerializeField] float dashCooldown = 1f;

    private bool dashing;
    private float currentDashCooldown;
    private float colliderOffset = -0.1f;
    private float colliderSize = 1.74f;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        rb2d = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (!dashing)
        {
            collider.offset = new Vector2(collider.offset.x, colliderOffset);
            collider.size = new Vector2(collider.size.x, colliderSize);
        }

        if (currentDashCooldown > 0)
        {
            currentDashCooldown -= Time.deltaTime;
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.performed && playerMovement.isGrounded && currentDashCooldown <= 0 && !dashing)
        {
            
            StartCoroutine(IsDashing());
        }
    }

    private void FixedUpdate()
    {
        if (dashing)
        {
            playerMovement.canMove = false;
            currentDashCooldown = dashCooldown;
            rb2d.gravityScale = 0;
            collider.size = new Vector2(collider.size.x, 0.60f);
            collider.offset = new Vector2(collider.offset.x, -0.50f);
            rb2d.velocity = new Vector2(dashSpeed * transform.localScale.x, 0);
            
        }
    }

    private IEnumerator IsDashing()
    {
        animator.SetTrigger("dash");
        animator.SetBool("dashing", true);
        dashing = true;
        playerMovement.canMove = false;

        yield return new WaitForSeconds(dashDuration);

        dashing = false;
        playerMovement.canMove = true;
        rb2d.gravityScale = playerMovement.baseGravity;
        animator.SetBool("dashing", false);
       
    }
}