//implemented by Rutherford and Landon

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {



    [SerializeField]            //allows us to edit value within Unity editor
    public float speed = 1f;    //player movement speed
    private float horizontal;
    private bool facingRight;
    [SerializeField]
    private Transform[] groundPoint;    //array for ground collisions. doesn't work yet
    [SerializeField]
    private float groundRad;            //ground radius
    [SerializeField]
    private LayerMask whatIsGround;     //used to specify what counts as ground
    private bool grounded;              //check if the player is grounded
    private bool jump;                  //check if the player has jumped
    [SerializeField]
    private float jump_speed;
    [SerializeField]
    private float jump_force;
    private bool attack;
    [SerializeField]
    public int phealth;             //player health
    private Animator playerAnimator;
    private Rigidbody2D rb2d;

    public GM gm;
    [SerializeField]
    public GameObject gameOver;


   

    // Use this for initialization
    void Start() {
        facingRight = true;
        rb2d = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

    }

    //FixedUpdate and HandleMovement implemented by Cameron and Landon
    //updates constantly. passes to HandleMovement
    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        grounded = IsGrounded();


        HandleMovement(horizontal);
        HandleAttacks();
        HandleLayers();
        Reset();
        flip(horizontal);
    }

    //Handles all major player movement functionality
    private void HandleMovement(float horizontal)
    {
        if (rb2d.velocity.y < 0)
        {
            playerAnimator.SetBool("land", true);
        }
        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);
        HandleInput();
        if (grounded && jump)
        {
            grounded = false;
            rb2d.AddForce(new Vector2(0, jump_force));
            playerAnimator.SetTrigger("jump");
        }

        playerAnimator.SetFloat("movSpeed", Mathf.Abs(horizontal));
    }

    //HandleInput, HandleAttacks and IsGrounded implemented by Rutherford and Abby
    //Handles attack variations
    private void HandleAttacks()
    {
        if (attack)
        {
            playerAnimator.SetTrigger("attack");
        }
    }

    //Handles the player being damaged as well as dying leading to a game over.
    public void TakeDamage()
    {
        phealth -= 1;
        if (phealth <= 0)
        {
            gm.GameOver();
        }
    }

    //Handles keystroke inputs for different actions
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.X) || Input.GetButtonDown("Fire2"))
        {

            //To Spawn Ducks

        }

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("Fire3"))
        {
            attack = true;

        }
    }
    //Detects when player is on the ground
    private bool IsGrounded()
    {
        if(rb2d.velocity.y <= 0)
        {
            foreach (Transform point in groundPoint)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRad, whatIsGround);
                for(int i=0; i < colliders.Length; i++)
                {
                    if(colliders[i].gameObject != gameObject)
                    {
                        playerAnimator.ResetTrigger("jump");
                        playerAnimator.SetBool("land", false);
                        return true;
                    }
                }
            }
        }
        return false;
    }
    // Rotates player animation
    private void flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }
    // Reset animation values
    private void Reset()
    {
        attack = false;
        jump = false;
    }

    private void HandleLayers()
    {
        if (!grounded)
        {
            playerAnimator.SetLayerWeight(1, 1);
        }
        else if(grounded)
        {
            playerAnimator.SetLayerWeight(1, 0);
        }
    }
}
