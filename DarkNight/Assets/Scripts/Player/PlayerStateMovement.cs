using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMovement
{
    // Player components
    private PlayerLogicMovement playerLogicMovement;
    private Rigidbody2D playerRigidBody;

    // Player movement states
    private enum MovementState { iddle, running, jumping, falling, dashing }

    // Others variables
    private bool flipX = false;


    public PlayerStateMovement() {  }

    public PlayerStateMovement(PlayerLogicMovement playerLogicMovement, Rigidbody2D playerRigidBody) 
    {
        this.playerLogicMovement = playerLogicMovement;
        this.playerRigidBody = playerRigidBody;
    }


    // Get player movement state
    public int GetPlayerStateMovement()
    {
        MovementState state;

        // Check velocity in X axis to determine if running or iddle
        if (this.playerRigidBody.velocity.x > .1f)
        {
            state = MovementState.running;
            this.flipX = false;
        }
        else if (this.playerRigidBody.velocity.x < -.1f)
        {
            state = MovementState.running;
            this.flipX = true;
        }
        else
        {
            state = MovementState.iddle;
        }
        
        // Check velocity in Y axis to determine if jumping or falling
        if (this.playerRigidBody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (this.playerRigidBody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        // Check dash with input
        if (this.playerLogicMovement.GetPlayerInputKeyboardMovement().GetPlayerMovement() == 2 && this.playerLogicMovement.GetIsDashable())
        {
            state = MovementState.dashing;
        }

        return (int) state;
    }
    

    public bool GetFlipX(){
        return this.flipX;
    }

}
