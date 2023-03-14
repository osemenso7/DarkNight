using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash
{

    private float dashTime;
    
    public Dash()
    {  
        this.dashTime = 0.25f;
    }

    public void MakeDash(Rigidbody2D playerRigidBody, SpriteRenderer playerSpriteRenderer, float dashForce)
    {
        if (playerSpriteRenderer.flipX == false)
        {
            playerRigidBody.velocity = new Vector2(dashForce, 0);
        }
        else
        {
            playerRigidBody.velocity = new Vector2(-dashForce, 0);
        }
    }

    public float GetDashTime(){
        return this.dashTime;
    }

}
