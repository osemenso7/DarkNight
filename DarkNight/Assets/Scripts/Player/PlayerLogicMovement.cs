using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogicMovement : MonoBehaviour
{

    // Player Components
    private Player player;
    private Rigidbody2D playerRigidBody;
    private SpriteRenderer playerSpriteRenderer;
    private BoxCollider2D playerBoxCollider;

    // Player movement input
    private PlayerInputKeyboardMovement playerInputKeyboardMovement;

    // Player movements
    private Movement movement;
    private Jump jump ;
    private Dash dash;

    // Player movement logic variables
    private float startGravity;
    private bool canMove = true;
    private bool isDashable = true;


    private void Start()
    {
        // Initialize variables 
        this.player = GetComponent<Player>();
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
                this.jump.MakeJump(this.playerRigidBody, this.player.GetjumpForce());
            }
            else if (action == 2 && isDashable)   // Dash
            {      
                StartCoroutine(DashControl());
            }
            else    // Move or iddle
            {
                this.movement.MakeMoveX(this.playerRigidBody, this.player.GetSpeed(), this.playerInputKeyboardMovement.GetDirX());
            }
        }

    }


    private IEnumerator DashControl()
    {
        // Check if the dash is completed and its cooldown
        this.isDashable = false;
        this.canMove = false;

        // With gravity = 0 we achieve a straight dash
        this.playerRigidBody.gravityScale = 0;

        this.dash.MakeDash(this.playerRigidBody, this.playerSpriteRenderer, this.player.GetDashForce());

        // Start dash cooldown
        StartCoroutine(DashCooldown());

        // Wait until the dash ends
        yield return new WaitForSeconds(this.dash.GetDashTime());

        this.playerRigidBody.gravityScale = this.startGravity;
        this.canMove = true;
    }

    private IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(this.player.GetDashCD());
        this.isDashable = true;
    }
    

    // Getters
    public PlayerInputKeyboardMovement GetPlayerInputKeyboardMovement(){
        return this.playerInputKeyboardMovement;
    }
    public bool GetIsDashable(){
        return this.isDashable;
    }
    
}
