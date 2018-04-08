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
    private Transform[] groundPoint;    //array for ground collisions
    [SerializeField]
    private float groundRad;            //ground radius
    [SerializeField]
    private LayerMask whatIsGround;     //used to specify what counts as ground
    //private bool grounded;              //check if the player is grounded
    //private bool jump;                  //check if the player has jumped
    [SerializeField]
    private float jump_speed;
    [SerializeField]
    private float jump_force;
    //private bool attack = false;
    [SerializeField]
    public int health;             //player health
    private Animator playerAnimator;
    private Rigidbody2D Rb2d { get; set; }

    public bool Attack { get; set; }
    public bool Jump { get; set; }
    public bool Grounded { get; set; }


    public GM gm;
   
    public HealthUI healthUI;

    [SerializeField]
    private EdgeCollider2D SwordCollider;
    [SerializeField]
    private List<string> damageSources;


   

    // Use this for initialization
    void Start() {
        facingRight = true;
        
        Rb2d = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

    }

    //FixedUpdate and HandleMovement implemented by Cameron and Landon
    //updates constantly. passes to HandleMovement
    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        Grounded = IsGrounded();


        HandleMovement(horizontal);
<<<<<<< HEAD

        
       // HandleLayers();

       
        //HandleLayers();

=======
        HandleAttacks();
        //HandleLayers();
>>>>>>> fa8707a63ccf06b4a1e99d3a25a91a6b5651c679
        Reset();
        flip(horizontal);
    }

    //Handles all major player movement functionality
    private void HandleMovement(float horizontal)
    {
        Rb2d.velocity = new Vector2(horizontal * speed, Rb2d.velocity.y);
        HandleInput();
        if (Grounded && Jump)
        {
            Grounded = false;
            Rb2d.AddForce(new Vector2(0, jump_force));
            playerAnimator.SetTrigger("jump");
        }

        playerAnimator.SetFloat("movSpeed", Mathf.Abs(horizontal));
    }

    //HandleInput, HandleAttacks and IsGrounded implemented by Rutherford and Abby
    //Handles attack variations
    private void HandleAttacks()
    {
<<<<<<< HEAD
        SwordCollider.enabled = !SwordCollider.enabled;
    }
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(damageSources.Contains(other.tag))
=======
        if (Attack)
        {
            Debug.Log("Attacking");
            playerAnimator.SetTrigger("attack");
            hitbox.SetActive(true);
            gm.WaitForAttack();
            hitbox.SetActive(false);
            Attack = false;
        }
        else
>>>>>>> fa8707a63ccf06b4a1e99d3a25a91a6b5651c679
        {
            TakeDamage();
        }
    }

    //Handles the player being damaged as well as dying leading to a game over.
    public void TakeDamage()
    {
        Debug.Log("Player taking damage");
        //hurtbox.SetActive(false);
        health -= 1;
        healthUI.UpdateHealth();  //update ui

        if (health <= 0)        //if player is dead, end game
        {
            Debug.Log("Game should end");
            gm.GameOver();
        }
        gm.Wait();
        //hurtbox.SetActive(true);
    }

  

    //Handles keystroke inputs for different actions
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            //playerAnimator.SetTrigger("jump");
            Jump = true;
        }

        if (Input.GetKeyDown(KeyCode.X) || Input.GetButtonDown("Fire2"))
        {

            //To Spawn Ducks

        }

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("Fire3"))
        {
<<<<<<< HEAD

            playerAnimator.SetTrigger("attack");
            HandleAttacks();

            //Attack = true;
            //playerAnimator.SetTrigger("attack");


=======
            Attack = true;
            //playerAnimator.SetTrigger("attack");

>>>>>>> fa8707a63ccf06b4a1e99d3a25a91a6b5651c679

        }
    }

    //Detects when player is on the ground
    private bool IsGrounded()
    {
        if(Rb2d.velocity.y <= 0)
        {
            foreach (Transform point in groundPoint)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRad, whatIsGround);
                for(int i=0; i < colliders.Length; i++)
                {
                    if(colliders[i].gameObject != gameObject)
                    {
                        playerAnimator.ResetTrigger("jump");
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
        Attack = false;
        Jump = false;
    }
    /*
    private void HandleLayers()
    {
        if (!grounded)
        {
            playerAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            playerAnimator.SetLayerWeight(1, -0.1f);
        }
    }*/
}
