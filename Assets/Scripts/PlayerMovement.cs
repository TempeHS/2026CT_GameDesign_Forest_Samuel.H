using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;
    public float acceleration = 12f;
    public float deceleration = 10f;
    private bool isFacingRight = true;
    public Animator animator;

    [Header("Jumping")]
    public float jumpForce = 20f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Dashing")]
    private bool canDash = true;
    private bool isDashing;
    private float dashingpower = 30f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;
    private Rigidbody2D rb;
    private float moveInput;
    private float currentVelocityX;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
{
    if (isDashing)
        return;

    moveInput = Input.GetAxisRaw("Horizontal");

    if (moveInput > 0 && !isFacingRight)
        Flip();
    else if (moveInput < 0 && isFacingRight)
        Flip();

    animator.SetFloat("Speed", Mathf.Abs(currentVelocityX));

    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

    if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        StartCoroutine(Dash());
    }

    private void Flip()
    {
    isFacingRight = !isFacingRight;
    Vector3 scale = transform.localScale;
    scale.x *= -1;
    transform.localScale = scale;
    }
    void FixedUpdate()
    {
         if (isDashing)
        {
            return;
        }
        float targetSpeed = moveInput * moveSpeed;
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            currentVelocityX = Mathf.Lerp(rb.linearVelocity.x, targetSpeed, acceleration * Time.fixedDeltaTime);
        }
        else
        {   
            currentVelocityX = Mathf.Lerp(rb.linearVelocity.x, 0, deceleration * Time.fixedDeltaTime);
        }
        rb.linearVelocity = new Vector2(currentVelocityX, rb.linearVelocity.y);
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
       rb.linearVelocity = new Vector2(moveInput * dashingpower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}