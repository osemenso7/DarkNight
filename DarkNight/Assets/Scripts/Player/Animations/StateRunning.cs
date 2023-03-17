using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateRunning : IPlayerState
{

    private Rigidbody2D playerRigidBody;
    private SpriteRenderer playerSpriteRenderer;


    public StateRunning()   {   }

    public StateRunning(Rigidbody2D playerRigidBody, SpriteRenderer playerSpriteRenderer)
    {
        this.playerRigidBody = playerRigidBody;
        this.playerSpriteRenderer = playerSpriteRenderer;
    }


    public int SetState(int state)
    {
        // Check velocity in X axis to determine if running or iddle
        if (this.playerRigidBody.velocity.x > .1f)
        {
            this.playerSpriteRenderer.flipX = false;
            return 1;
        }
        
        if (this.playerRigidBody.velocity.x < -.1f)
        {
            this.playerSpriteRenderer.flipX = true;
            return 1;
        }
        return state;
    }
}
