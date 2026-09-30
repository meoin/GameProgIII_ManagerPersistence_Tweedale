using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private float moveInput;
    public float speed = 5f;
    public float jumpStrength = 5f;
    public float runMultiplier = 1.5f;
    private bool running = false;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer renderer;

    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        Vector2 velocity = rb.linearVelocity;

        velocity.x = moveInput * speed;

        animator.SetBool("Moving", Mathf.Abs(velocity.x) > 0);

        if (velocity.x < 0) renderer.flipX = true;
        else if (velocity.x > 0) renderer.flipX = false;

        if (running)
        {
            velocity.x *= runMultiplier;
            if (Mathf.Abs(velocity.x) > 0)
            {
                animator.speed = 2.0f;
            }
        }
        else 
        {
            animator.speed = 1.0f;
        }


            rb.linearVelocity = velocity;
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        moveInput = context.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context) 
    {
        if (context.started && isGrounded) 
        {
            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        }
        else if (context.canceled) 
        {
            Vector2 velocity = rb.linearVelocity;

            if (velocity.y > 0) velocity.y = 0;

            rb.linearVelocity = velocity;
        }
    }

    public void OnSprint(InputAction.CallbackContext context) 
    {
        if (context.started) running = true;
        else if (context.canceled) running = false;
    }
}
