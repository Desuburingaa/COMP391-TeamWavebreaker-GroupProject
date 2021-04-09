using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject slashVFXRight;
    [SerializeField] GameObject slashVFXLeft;
    [SerializeField] GameObject SlashSpawner;

    //public variables
    public float playerSpeed = 2.5f; //how fast player moves
    public float jumpForce = 5.5f;  //how high player can jump
    public Transform groundCheck; //the transform Gobj within which the circle collider will be spawned
    public float checkRadius; //the radius of the circle collider
    public LayerMask whatIsGround; //the layer where the platforms (and anything else) will be considered as the ground
    public int wallJumps; // how many extra jumps the player gets (default 0)
    public Transform frontCheck; //same as groundcheck but for front
    public float wallSlidingSpeed; //how fast character slides off of walls
    public float xWallForce; //xforce for wall jumping
    public float yWallForce; //yforce for wall jumping
    public float wallJumpTime; //how long the forces get applied
    public float attackCoolDown; //how long player must wait before attacking again





    //components
    private Rigidbody2D rbody;  //create a local variable for Rigidbody2D

    //private variables
    private float moveInput; //detect if player has input keys pressed
    bool facingRight = true; //for flipping the character to face the right direction
    private bool isGrounded; //for checking if player is in the air (for jumps)
    public int jumps; //how many jumps the player has (walljumps) at any given time
    private bool isTouchingFront; //this is to help check if there is a wall in front of the player
    private bool isWallSliding; // used to determine if wallsliding condidtions apply
    private bool isWallJumping; //for walljumping
    private bool isAttacking = false;





    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        jumps = wallJumps;
        
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); //this creats a circle collider at a position (under player) on the layer labelled whatIsGround
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");

        rbody.velocity = new Vector2(moveInput * playerSpeed, rbody.velocity.y); //sets the x velocity

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true) //player has to be on ground if jumping
        {
            rbody.velocity = Vector2.up * jumpForce; // shorthand for creating an vector2 where x is 0 and y is 1, multiply by jumpForce

        }
        //else if(Input.GetKeyDown(KeyCode.Space) && jumps <= 0 && isGrounded == true) // if player is on the ground when attempting the jump
        //{
        //    rbody.velocity = Vector2.up * jumpForce;
        //}
        if(isGrounded == true) //once player touches ground, then the counter gets "refilled"
        {
            jumps = wallJumps;
        }

        if (isTouchingFront == true && isGrounded == false && moveInput!= 0) //if there is a platform/wall in front of player, and player is NOT on the ground, and player is pushing a directional key apply wall slide conditions
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }

        if (isWallSliding == true)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, Mathf.Clamp(rbody.velocity.y, -wallSlidingSpeed, float.MaxValue)); // so player can jump as high as he wants but the min cannot be lower than wallsliding speed (down)
        }

        if (Input.GetKeyDown(KeyCode.Space) && isWallSliding == true && jumps > 0)
        {
            isWallJumping = true;
            Invoke("SetIsWallJumpingToFalse", wallJumpTime); // invokes method after a set amount of time; **Warning** if code name is changed, this will break!!!!
        }

        if(isWallJumping == true)
        {
            rbody.velocity = new Vector2(xWallForce*(-moveInput), yWallForce); //the reason moveInput is negative is so that it will "bounce" away from the wall
        }


        if (Input.GetKeyDown(KeyCode.X) && isAttacking == false)
        {
            isAttacking = true;
            AttackEffect();
            Invoke("SetAttackingToFalse", attackCoolDown);
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale; //take GObj scales
        scaler.x *= -1; //flip along x axis.
        transform.localScale = scaler; //make this flip the new norm
    }

    void SetIsWallJumpingToFalse()
    {
        isWallJumping = false;
        jumps--; // once character force has been applied, then remove a jump from the player (default one jump off of wall)
    }

    public void AttackEffect()
    {
        
        if(facingRight == false)
        {
            GameObject _ = Instantiate(slashVFXLeft, SlashSpawner.transform.position, Quaternion.identity);
            _.transform.SetParent(SlashSpawner.transform);

        }
        else if(facingRight == true)
        {
            GameObject _ = Instantiate(slashVFXRight, SlashSpawner.transform.position, Quaternion.identity);
            _.transform.SetParent(SlashSpawner.transform);
        }

    }

    private void SetAttackingToFalse()
    {
        isAttacking = false;
    }
}
