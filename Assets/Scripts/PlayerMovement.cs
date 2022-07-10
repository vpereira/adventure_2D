using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private bool wallSliding = false;
    private bool wallJumping = false;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float coyoteTime = 0.2f;
    [SerializeField] private float wallSlidingSpeed = -2f; //it must be negative since we are applying it downwards
    [SerializeField] private float coyoteTimeCounter;
    [SerializeField] private float xWallForce;
    [SerializeField] private float yWallForce;
    [SerializeField] private float wallJumpTime;
    [SerializeField] private float jumpBufferTime;
    [SerializeField] private float jumpBufferCounter;


    private enum MovementState { idle, running, jumping, falling }

    private MovementState state;

    [SerializeField] private AudioSource jumpSoundEffect;

    [SerializeField] private ParticleSystem dust;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

       wallSliding = IsWallSliding(dirX);

        if (wallSliding)
        {
            setWallSlidingSpeed();
        }
        else
        {
            // To avoid to try to run while wallSliding
            run(dirX);
        }    

        if (IsGrounded())
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
            jumpBufferCounter = jumpBufferTime;
        else
            jumpBufferCounter -= Time.deltaTime;

        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpBufferCounter = 0;
        }

        // Just add support for short jumps. 
        if (jumpBufferCounter > 0f && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }

        

        if (jumpBufferCounter > 0f && wallSliding)
        {
            setJumpTime();
        }

        if (wallJumping)
        {
            setWallJumpingVelocity(dirX);
        }

        UpdateAnimationState();
        playDust();
    }

    private void run(float dirX)
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    private bool IsWallSliding(float dirX)
    {
        return (IsHittingWall() && !IsGrounded() && dirX != 0);
    }

    private void setWallSlidingSpeed()
    {
        rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, wallSlidingSpeed, float.MaxValue));
    }

    private void setJumpTime()
    {
        wallJumping = true;
        // Player is just possible to wall jump withing the defined wallJumpTime
        Invoke("resetWallJumping", wallJumpTime);
    }

    private void setWallJumpingVelocity(float dirX)
    {
        // apply xWallForce * inverted direction, to jump in another direction in X axis
        rb.velocity = new Vector2(xWallForce * -dirX, yWallForce);
    }

    private void resetWallJumping()
    {
        wallJumping = false;
    }

    private void UpdateAnimationState()
    {

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }


        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void createDust()
    {
        dust.Play();
    }

    private void playDust()
    {
        if (state == MovementState.running || state == MovementState.jumping)
            createDust();
    }
    private bool IsHittingWall()
    {
        return Physics2D.Raycast(transform.position, transform.right, .5f, jumpableGround);
    }
}