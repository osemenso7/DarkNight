using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : IMovement
{

    private Rigidbody2D playerRigidBody;
    private float jump;

    
    public Jump(){  }

    public Jump(Rigidbody2D playerRigidBody, float jump)
    {
        this.playerRigidBody = playerRigidBody;
        this.jump = jump;
    }


    // Apply velocity in Y axis
    public void MakeMove()
    {
        this.playerRigidBody.velocity = new Vector2(this.playerRigidBody.velocity.x, this.jump);
    }

}
