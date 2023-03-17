using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDashing : IPlayerMovementObserver
{
    
    private PlayerLogicMovement playerLogicMovementObservable;
    private bool isDashing = false;


    public StateDashing() {   }

    public StateDashing(PlayerLogicMovement playerLogicMovementObservable) 
    {
        this.playerLogicMovementObservable = playerLogicMovementObservable;
        this.playerLogicMovementObservable.SetPlayerMovementObserver(this);
    }
    

    public int SetState(int state)
    {
        if (this.isDashing)
        {
            this.isDashing = false;
            return 4;
        }
        return state;
    }

    public void CheckMovement()
    {
        this.isDashing = true;
    }
}
