using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFalling : IPlayerState
{
    
    private Rigidbody2D playerRigidBody;


    public StateFalling()   {   }

    public StateFalling(Rigidbody2D playerRigidBody)
    {
        this.playerRigidBody = playerRigidBody;
    }


    public int SetState(int state)
    {
        if (this.playerRigidBody.velocity.y < -.1f)
        {
            return 3;
        }
        return state;
    }
}
