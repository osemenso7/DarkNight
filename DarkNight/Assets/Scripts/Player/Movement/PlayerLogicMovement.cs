using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogicMovement : MonoBehaviour, IPlayerCollisionObserver, IPlayerMovementHandler
{

    // Player Components
    private Player player;
    private Rigidbody2D playerRigidBody;
    private SpriteRenderer playerSpriteRenderer;

    // Player logic
    private PlayerCollisionGroundHandler playerCollisionGround;
    private PlayerInputKeyboardMovement playerInputKeyboardMovement;
    private IPlayerMovementObserver playerMovementObserver;

    // Player movements
    private Movement movement;
    private Jump jump ;
    private Dash dash;

    // Player movement logic variables
    private bool canMove = true;
    private bool isGrounded = true;
    private bool airDash = true;
    private int doubleJump = 0;


    private void Start()
    {
        // Initialize variables 
        this.player = GetComponent<Player>();
        this.playerRigidBody = GetComponent<Rigidbody2D>();
        this.playerSpriteRenderer = GetComponent<SpriteRenderer>();

        this.playerInputKeyboardMovement = new PlayerInputKeyboardMovement();
        this.playerCollisionGround = GetComponent<PlayerCollisionGroundHandler>();
        this.playerCollisionGround.SetPlayerCollisionObserver(this);

        this.movement = new Movement(this.playerRigidBody, this.player.GetSpeed(), this.playerInputKeyboardMovement.GetDirX());
        this.jump = new Jump(this.playerRigidBody, this.player.GetjumpForce());
        this.dash = GetComponent<Dash>();
    }

    private void Update()
    {

        // Get input from keyboard
        int action = this.playerInputKeyboardMovement.GetPlayerMovement();
        this.canMove = this.dash.GetDashController().GetCanMove();

        if (this.canMove)
        {
            if (action == 1 && (this.isGrounded || doubleJump < 2))    // Jump
            {
                this.jump.MakeMove();
                isGrounded = false;
                doubleJump++;
            }
            else if (action == 2 && this.dash.GetDashController().GetIsDashable())   // Dash
            {      
                if (this.isGrounded)
                {
                    this.SetStateMovement();
                    this.dash.MakeMove();
                }
                else
                {
                    if (this.airDash)
                    {
                        this.SetStateMovement();
                        this.dash.MakeMove();
                        this.airDash = false;
                    }
                }
            }
            else    // Move or iddle
            {
                this.movement.SetDirX(this.playerInputKeyboardMovement.GetDirX());
                this.movement.MakeMove();
            }
        }

    }

    public void SetIsGrounded()
    {
        this.isGrounded = true;
        this.airDash = true;
        this.doubleJump = 0;
    }

    public void SetPlayerMovementObserver(IPlayerMovementObserver playerMovementObserver)
    {
        this.playerMovementObserver = playerMovementObserver;
    }

    public void SetStateMovement()
    {
        this.playerMovementObserver.CheckMovement();
    }
}
