using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    //necessary for animations/physics
    private Rigidbody2D rb2d;
    private Animator myAnimator;

    private bool facingRight = true;

    //variables to play with
    public float speed = 2.0f;
    public float horizMovement;     //horizontal movement. This equals, 1 -1 or 0


    // Start is called before the first frame update
    private void Start()
    {
        //define the game objects found on player
        rb2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    //Handles input for physics
    private void Update()
    {
        //check direction given by player
        horizMovement = Input.GetAxis("Horizontal");

    }

    //handles running physics
    private void FixedUpdate()
    {
        //move the character left/right
        rb2d.velocity = new Vector2(horizMovement * speed, rb2d.velocity.y);
        myAnimator.SetFloat("speed", Mathf.Abs(horizMovement));
        Flip(horizMovement);
        
    }

    //flip function
    private void Flip(float horizonal)
    {
        if (horizonal < 0 && facingRight || horizonal > 0 && !facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
 