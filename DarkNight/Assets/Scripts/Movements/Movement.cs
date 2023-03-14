using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    
    public Movement(){  }

    public void MakeMoveX(Rigidbody2D playerRigidBody, float speed, float dirX)
    {
        playerRigidBody.velocity = new Vector2(dirX * speed, playerRigidBody.velocity.y);
    }
}
