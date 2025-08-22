using UnityEngine;
using UnityEngine.InputSystem;

public class Platform : MonoBehaviour
{
    Collider2D platform;
    public bool isOver;
    public void Start()
    {
        platform = GetComponent<Collider2D>();
        input.Player.Drop.performed += PlatformDrop;
    }
    public void PlatformDrop(InputAction.CallbackContext ctx)
    {
        if (!isOver) return;
        isOver = platform.enabled = false;
        Invoke(nameof(PlatformReset), 0.25f);
    }
    public void PlatformReset()
    {
        platform.enabled = true;
    }   

    PlayerInputs input;
    private void Awake() => input = new PlayerInputs();
    private void OnEnable() => input.Enable();
    private void OnDisable() => input.Disable();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOver = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isOver = false;
        }
    }

}
