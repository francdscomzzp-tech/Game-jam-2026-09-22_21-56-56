using UnityEngine;
using UnityEngine.InputSystem;
public class scri : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpPower = 16;
    public float speed = 8f;
    private int direzione;

    public Transform groundCheck;
    public LayerMask groundLayer;
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.dKey.isPressed)
        {
            direzione = 1;
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            direzione = -1;
        }
        else
        {
            direzione = 0;
        }
        if (direzione != 0)
        {
            transform.localScale = new Vector3(direzione, 1, 1);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && IsGrounded()) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpPower);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direzione * speed, rb.linearVelocityY);
    }
    
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }
}
