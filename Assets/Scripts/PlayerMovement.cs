using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]            //allows us to edit value within Unity editor
    public float speed = 1f;    //player movement speed
    private float horizontal;
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
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    //updates constantly. passes to HandleMovement
    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        grounded = IsGrounded();
        HandleInput();
        HandleMovement(horizontal);
    }

    //Handles all major player movement functionality
    private void HandleMovement(float horizontal)
    {
        rb2d.velocity = new Vector2(horizontal * speed, rb2d.velocity.y);
        if(grounded && jump)
        {
            grounded = false;
            rb2d.AddForce(new Vector2(0, jump_force));
        }
    }


    private void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

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
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
