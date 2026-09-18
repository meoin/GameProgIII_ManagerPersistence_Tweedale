using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private float moveInput;
    public float speed = 5f;
    public float jumpStrength = 5f;
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

        rb.linearVelocity = velocity;
    }

    public void OnMove(InputValue input) 
    {
        moveInput = input.Get<float>();
    }

    public void OnJump() 
    {
        Debug.Log("Player jumped");

        rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
    }
}
