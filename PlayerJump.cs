using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    [Header("Jump Details")]
    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedJumping;

    [Header("Ground Details")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float radOfCircle;

    public bool grounded;

    [Header("Components")]
    private Rigidbody2D rb;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimeCounter = jumpTime;
    }

    private void Update()
    {
        //what it means to be grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, radOfCircle, whatIsGround);

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
        }

        //if we press jump button
        if(Input.GetButtonDown("Jump") && grounded)
        {
            //jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            stoppedJumping = false;
        }

        //if we hold button down, keep jumping. Else, shorthop
        if (Input.GetButton("Jump") && !stoppedJumping && (jumpTimeCounter > 0) )
        {
            //jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
        }

        //if we release jump button
        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, radOfCircle);
    }
}
