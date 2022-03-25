using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    Vector3 velocity = Vector3.zero;

    bool isJumping = false;
    public bool isGroudned = true;
    public float jumpeForce;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    void FixedUpdate()
    {
        isGroudned = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && isGroudned) isJumping = true;
        Flip(rb.velocity.x);
        MovePlayer(horizontalMovement);
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));

    }

    public void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpeForce));
            isJumping = false;
        }

    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
