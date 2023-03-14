using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump
{
    
    public Jump(){  }

    public void MakeJump(Rigidbody2D playerRigidBody, float jump)
    {
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jump);
    }

}
