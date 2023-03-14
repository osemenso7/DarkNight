using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogicMovement : MonoBehaviour
{

    // Player stats
    [SerializeField] private float speed = 7f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float dashForce = 20f;

    // Player Components
    private Rigidbody2D playerRigidBody;
    private SpriteRenderer playerSpriteRenderer;
    private BoxCollider2D playerBoxCollider;

    // Player movement logic controller
    private PlayerInputKeyboardMovement playerInputKeyboardMovement;
    private bool canMove = true;
    private float startGravity;

    // Player movements
    private Movement movement;
    private Jump jump ;
    private Dash dash;


    private void Start()
    {
        // Initialize variables 
        this.playerRigidBody = GetComponent<Rigidbody2D>();
        this.playerSpriteRenderer = GetComponent<SpriteRenderer>();
        this.playerBoxCollider = GetComponent<BoxCollider2D>();

        this.playerInputKeyboardMovement = new PlayerInputKeyboardMovement();
        this.startGravity = this.playerRigidBody.gravityScale;

        this.movement = new Movement();
        this.jump = new Jump();
        this.dash = new Dash();
    }

    private void Update(){

        // Get input from keyboard
        int action = playerInputKeyboardMovement.GetPlayerMovement();

        if (this.canMove)
        {
            if (action == 1)    // Jump
            {
                this.jump.MakeJump(this.playerRigidBody, this.jumpForce);
            }
            else if (action == 2)   // Dash
            {      
                StartCoroutine(DashControl());
            }
            else    // Move or iddle
            {
                this.movement.MakeMoveX(this.playerRigidBody, this.speed, this.playerInputKeyboardMovement.GetDirX());
            }
        }

    }

    private IEnumerator DashControl()
    {
        // With canMove = false we avoid changing the player velocity in the X axis during the dash
        this.canMove = false;

        // With gravity = 0 we achieve a straight dash
        this.playerRigidBody.gravityScale = 0;

        this.dash.MakeDash(this.playerRigidBody, this.playerSpriteRenderer, this.dashForce);

        // Wait until the dash ends
        yield return new WaitForSeconds(this.dash.GetDashTime());

        this.playerRigidBody.gravityScale = this.startGravity;

        this.canMove = true;
    }
    
}
