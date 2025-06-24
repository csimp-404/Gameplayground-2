using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CharacterStats stats;
    private Vector2 movementInput;
    private SpriteRenderer spriteRenderer;
    private Animator anim;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<CharacterStats>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        // Read movement input from keyboard
        movementInput.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right Arrow
        movementInput.y = Input.GetAxisRaw("Vertical");   // W/S or Up/Down Arrow
        if (movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
            FlipChildren(false);
        }
        else if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
            FlipChildren(true);
        }
    }

    private void FixedUpdate()
    {
        // Apply movement velocity
        rb.linearVelocity = movementInput.normalized * stats.moveSpeed;
        anim.SetFloat("Speed", rb.linearVelocity.magnitude);
    }

    private void FlipChildren(bool flip)
    {
        foreach (Transform child in transform)
        {
            // Check if the child has a SpriteRenderer component
            SpriteRenderer childSprite = child.GetComponent<SpriteRenderer>();
            if (childSprite != null)
            {
                // Flip the sprite renderer (without affecting the scale)
                childSprite.flipX = flip;
            }
        }
    }
}

