using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private float dirX;
    
    [SerializeField] private float moveSpeed = 14;
    [SerializeField] private float jumpForce = 20;
    
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Collider2D coll;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        
        dirX = Input.GetAxisRaw("Horizontal");
        
        rb.linearVelocity = new Vector2(dirX * moveSpeed , rb.linearVelocity.y);

        UpdateAnimationState();
    }

    void UpdateAnimationState()
    {
        if (dirX > 0)
        {
            animator.SetBool("isRunning",true);
            spriteRenderer.flipX = false;
        }
        else if (dirX < 0)
        {
            animator.SetBool("isRunning",true);
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool("isRunning",false);
        }
        
    }

    private bool IsGrounded()
    {
        return Physics2D.CapsuleCast(coll.bounds.center, coll.bounds.size,CapsuleDirection2D.Vertical,
            0f, Vector2.down, 0.1f, groundLayer);
    }
    
}
