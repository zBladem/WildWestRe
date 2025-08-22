using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    bool isFacingRight = true;
    public PlayerCombat combat;
    public PlayerHealth health;
    Animator animator;
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool canMove = true;
    public float baseGravity;

    [Header("Movement")]
    [SerializeField] private float Speed = 8f;
    float defaultSpeed;
    float horizontal;

    [Header("Jump")]
    [SerializeField] private float JumpForce = 10f;
    [SerializeField] private float cooldownjump = 1;

    [Header("GroundCheck")]
    [SerializeField] Transform groundCheckPos;
    [SerializeField] Vector2 groundCheckSize = new (0.5f, 0.05f);
    public LayerMask groundLayer;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        defaultSpeed = Speed;
        combat = GetComponent<PlayerCombat>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Gravity();
        GroundCheck();
        Flip();
        animator.SetFloat("velocityY", rb2d.velocity.y);
        cooldownjump -= Time.deltaTime;
       
        if (canMove && !health.damaged)
        {
            rb2d.velocity = new Vector2(horizontal * defaultSpeed, rb2d.velocity.y);
        }
    }

    #region CONTROL_INPUTS  

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            horizontal = context.ReadValue<Vector2>().x;          
        }
        if (horizontal == 0)
        {
            animator.SetInteger("RunState", 0);
        }
        else if (horizontal != 0)
        {
            animator.SetInteger("RunState", 1);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded && context.performed && cooldownjump <= 0 && canMove)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, JumpForce);
            animator.SetTrigger("jump");
            cooldownjump = 0.5f;
        }
    }
    #endregion

    #region PLAYER_MODIFIERS      
    private void Flip()
    {
        if (isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    public bool GroundCheck()
    {
        if (Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            isGrounded = true;
            animator.SetBool("grounded", true);
            return true;
        }
        else
        {
            isGrounded = false;
            animator.SetBool("grounded", false);
            return false;
        }
    }

    private void Gravity()
    {
        if (rb2d.velocity.y < 0)
        {
            rb2d.gravityScale = baseGravity * 2f;
            rb2d.velocity = new Vector2(rb2d.velocity.x, Mathf.Max(rb2d.velocity.y, -20f));
        }
        else
        {
            rb2d.gravityScale = baseGravity;
        }
    }

    public void AdjustSpeed(float newSpeed)
    {
        defaultSpeed = newSpeed;
    }

    public float GetSpeed()
    {
        return defaultSpeed = Speed;
    }
    #endregion

    #region GIZMO
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
    #endregion
}