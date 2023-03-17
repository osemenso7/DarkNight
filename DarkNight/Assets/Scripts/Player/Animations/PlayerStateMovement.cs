using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMovement
{
    // Player components
    private Rigidbody2D playerRigidBody;
    private SpriteRenderer playerSpriteRenderer;
    private PlayerLogicMovement playerLogicMovementObservable;

    // States
    private StateIddle stateIddle;
    private StateRunning stateRunning;
    private StateJumping stateJumping;
    private StateFalling stateFalling;
    private StateDashing stateDashing;
    private int state = 0;


    public PlayerStateMovement() {  }

    public PlayerStateMovement(Rigidbody2D playerRigidBody, SpriteRenderer playerSpriteRenderer, PlayerLogicMovement playerLogicMovementObservable) 
    {
        this.playerRigidBody = playerRigidBody;
        this.playerSpriteRenderer = playerSpriteRenderer;
        this.playerLogicMovementObservable = playerLogicMovementObservable;

        this.stateIddle = new StateIddle();
        this.stateRunning = new StateRunning(this.playerRigidBody, this.playerSpriteRenderer);
        this.stateJumping = new StateJumping(this.playerRigidBody);
        this.stateFalling = new StateFalling(this.playerRigidBody);
        this.stateDashing = new StateDashing(this.playerLogicMovementObservable);
    }


    // Get player movement state
    public int GetPlayerStateMovement()
    {
        this.state = this.stateIddle.SetState(state);
        this.state = this.stateRunning.SetState(state);
        this.state = this.stateJumping.SetState(state);
        this.state = this.stateFalling.SetState(state);
        this.state = this.stateDashing.SetState(state);

        return (int) state;
    }

}
