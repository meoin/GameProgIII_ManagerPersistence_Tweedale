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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 velocity = rb.linearVelocity;

        velocity.x = moveInput * speed;

        if (running) velocity.x *= runMultiplier;

        rb.linearVelocity = velocity;
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        moveInput = context.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context) 
    {
        if (context.started) 
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
