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
    private bool canMove = true;


    private void Start()
    {
        // Initialize variables 
        this.player = GetComponent<Player>();
        this.playerRigidBody = GetComponent<Rigidbody2D>();
        this.playerSpriteRenderer = GetComponent<SpriteRenderer>();
        this.playerBoxCollider = GetComponent<BoxCollider2D>();

        this.playerInputKeyboardMovement = new PlayerInputKeyboardMovement();

        this.movement = new Movement(this.playerRigidBody, this.player.GetSpeed(), this.playerInputKeyboardMovement.GetDirX());
        this.jump = new Jump(this.playerRigidBody, this.player.GetjumpForce());
        this.dash = GetComponent<Dash>();
    }

    private void LateUpdate(){

        // Get input from keyboard
        int action = this.playerInputKeyboardMovement.GetPlayerMovement();
        this.canMove = this.dash.GetDashController().GetCanMove();

        if (this.canMove)
        {
            if (action == 1)    // Jump
            {
                this.jump.MakeMove();
            }
            else if (action == 2 && this.dash.GetDashController().GetIsDashable())   // Dash
            {      
                this.dash.MakeMove();
            }
            else    // Move or iddle
            {
                this.movement.SetDirX(this.playerInputKeyboardMovement.GetDirX());
                this.movement.MakeMove();
            }
        }

    }
    

    // Getters
    public PlayerInputKeyboardMovement GetPlayerInputKeyboardMovement(){
        return this.playerInputKeyboardMovement;
    }
    public bool GetIsDashable(){
        return this.dash.GetDashController().GetIsDashable();
    }
    
}
