using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateJumping : IPlayerState
{
    
    private Rigidbody2D playerRigidBody;


    public StateJumping()   {   }

    public StateJumping(Rigidbody2D playerRigidBody)
    {
        this.playerRigidBody = playerRigidBody;
    }


    public int SetState(int state)
    {
        if (this.playerRigidBody.velocity.y > .1f)
        {
            return 2;
        }
        return state;
    }
}
