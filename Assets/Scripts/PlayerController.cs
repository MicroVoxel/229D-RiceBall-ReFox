using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float 
        acceleration,
        maxSpeed,
        jumpForce
        ;
    [Range(0f, 1f)]
    public float deceleration;

    public bool isJumping;
    private float moveInput;
    private bool moveJump;

    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckInput();
        Jumping();
    }

    private void FixedUpdate()
    {
        Moving();
        Friction();
    }

    private void LateUpdate()
    {
        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocityX));
        animator.SetFloat("yVelocity", rb.linearVelocityY);
    }

    void CheckInput()
    {
        moveInput = Input.GetAxis("Horizontal");
        moveJump = Input.GetButtonDown("Jump");
    }

    void Moving()
    {
        if (Mathf.Abs(moveInput) > 0)
        {
            float increment = moveInput * acceleration;
            float newSpeed = Mathf.Clamp(rb.linearVelocityX + increment, -maxSpeed, maxSpeed);
            rb.linearVelocity = new Vector2(newSpeed, rb.linearVelocityY);

            FaceDirection();
        }
    }

    void FaceDirection()
    {
        float direction = Mathf.Sign(moveInput);
        float face = transform.localScale.x;
        if (face < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -direction, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x * direction, transform.localScale.y, transform.localScale.z);
        }
    }

    void Jumping()
    {
        if (moveJump && !isJumping)
        {
            rb.AddForce(new Vector2(rb.linearVelocityX, jumpForce), ForceMode2D.Impulse);

        }
    }

    void Friction()
    {
        if (!isJumping && moveInput == 0) 
        {
            float x = Mathf.MoveTowards(rb.linearVelocityX, 0f, deceleration);
            rb.linearVelocityX = x;
        }
    }
}
