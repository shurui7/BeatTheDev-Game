using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 5f;
    private float jumpingPower = 16f;
    private int jumpsLeft = 2; // Track the number of jumps left
    private bool isFacingRight = true;
    private bool isWalking = false; // Track if the player is currently walking

    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public int maxJumps = 2; // Define maximum number of jumps
    private SoundManagerScript soundManager; // Added reference to SoundManagerScript

    void Start()
    {
        soundManager = FindObjectOfType<SoundManagerScript>(); // Finding SoundManagerScript in the scene
    }

    void Update()
    {
        // Check if the player is attacking
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                if (soundManager != null) // Added null check for soundManager
                {
                    soundManager.PlaySound("jump");
                }
                jumpsLeft = maxJumps - 1; // Reset jumps left when grounded
            }
            else if (jumpsLeft > 0) // Perform additional jumps if available
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                jumpsLeft--; // Decrement jumps left
            }
        }

        Flip();
    }

    private void FixedUpdate()
    {
        // Check if the player is attacking

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (Mathf.Abs(horizontal) > 0.1f)
        {
            anim.SetBool("Run", true);
            if (!isWalking && soundManager != null) // Check if not already walking
            {
                soundManager.PlaySound("walk"); // Play the walk sound
                isWalking = true; // Set walking flag to true
            }
        }
        else
        {
            anim.SetBool("Run", false);
            if (isWalking && soundManager != null) // Check if walking and soundManager is not null
            {
                soundManager.StopWalkSound(); // Stop the walk sound
                isWalking = false; // Reset walking flag when not walking
            }
        }

        if (Mathf.Abs(rb.velocity.y) > 0.1f)
        {
            if (rb.velocity.y < -0.1f) // Check if falling
            {
                anim.SetBool("Fall", true);
                anim.SetBool("Jump", false);
            }
            else
            {
                anim.SetBool("Jump", true);
                anim.SetBool("Fall", false); // Reset fall animation
            }
        }
        else
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", false);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
