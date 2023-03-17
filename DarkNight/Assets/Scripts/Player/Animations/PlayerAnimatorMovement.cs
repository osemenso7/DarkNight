using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorMovement : MonoBehaviour
{

    // Player components
    private Rigidbody2D playerRigidBody;
    private SpriteRenderer playerSpriteRenderer;
    private Animator playerAnimatorMovement;

    // Player state movement
    private PlayerStateMovement playerStateMovement;
    private PlayerLogicMovement playerLogicMovementObservable;

    // Others variables
    private string STATE_ANIM = "stateMovement";
    

    void Start()
    {
        // Initialize variables 
        this.playerRigidBody = GetComponent<Rigidbody2D>();
        this.playerSpriteRenderer = GetComponent<SpriteRenderer>();
        this.playerAnimatorMovement = GetComponent<Animator>(); 
        this.playerLogicMovementObservable = GetComponent<PlayerLogicMovement>();

        this.playerStateMovement = new PlayerStateMovement(this.playerRigidBody, this.playerSpriteRenderer, this.playerLogicMovementObservable);
    }

    void Update()
    {
        this.playerAnimatorMovement.SetInteger(STATE_ANIM, this.playerStateMovement.GetPlayerStateMovement());
    }

}
