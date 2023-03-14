using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMovement : MonoBehaviour
{
    // Player components
    Rigidbody2D playerRigidBody;

    // Player movement states
    private enum MovementState { iddle, running, jumping, falling, dashing }

    private void Start()
    {
        // Initialize variables
        this.playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Debug.Log(getPlayerStateMovement());
    }

    // Get player movement state
    public int getPlayerStateMovement()
    {

        MovementState state;

        // Check velocity in X axis to determine if running or iddle
        if (this.playerRigidBody.velocity.x != 0f)
        {
            state = MovementState.running;
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

        // Check gravity of the player to determine id dashing
        if (this.playerRigidBody.gravityScale == 0)
        {
            state = MovementState.dashing;
        }

        return (int) state;

    }

}
