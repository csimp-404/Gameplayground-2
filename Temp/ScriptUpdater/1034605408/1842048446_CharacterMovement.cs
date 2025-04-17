using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CharacterStats stats;
    private Vector2 movementInput;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    public CharacterAttack attackScript;


    public bool isSprinting;
    private float speed;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<CharacterStats>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        speed = stats.moveSpeed;
        attackScript = GetComponent<CharacterAttack>();


    }

    private void Update()
    {
        if (attackScript != null && attackScript.IsAttacking)
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            return;
        }

        // Read movement input from keyboard
        movementInput.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right Arrow
        movementInput.y = Input.GetAxisRaw("Vertical");   // W/S or Up/Down Arrow

        if (movementInput.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(movementInput.x), 1, 1);
        }

        // Toggle sprinting based on key press
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
            anim.SetBool("IsSprinting", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
            anim.SetBool("IsSprinting", false);
        }
    }

    private void FixedUpdate()
    {
        // Apply movement velocity with sprinting
        float moveSpeed = isSprinting ? stats.moveSpeed * 2 : stats.moveSpeed;
        rb.linearVelocity = movementInput.normalized * moveSpeed;

        anim.SetFloat("Speed", rb.linearVelocity.magnitude);
    }
}


