using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : IMovement
{

    private Rigidbody2D playerRigidBody;
    private float speed;
    private float dirX;

    
    public Movement(){  }

    public Movement(Rigidbody2D playerRigidBody, float speed, float dirX)
    { 
        this.playerRigidBody = playerRigidBody;
        this.speed = speed;
        this.dirX = dirX;
    }


    // Apply velocity in X axis
    public void MakeMove()
    {
        this.playerRigidBody.velocity = new Vector2(this.dirX * this.speed, this.playerRigidBody.velocity.y);
    }


    // Setter
    public void SetDirX(float dirX){
        this.dirX = dirX;
    }
}
