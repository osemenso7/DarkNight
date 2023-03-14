using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorMovement : MonoBehaviour
{

    // Player components
    private Player player;
    private Rigidbody2D playerRigidBody;
    private SpriteRenderer playerSpriteRenderer;
    private Animator playerAnimatorMovement;

    // Player state movement
    private PlayerLogicMovement playerLogicMovement;
    private PlayerStateMovement playerStateMovement;

    // Others variables
    private string STATE_ANIM = "stateMovement";
    private int state = 0;
    

    void Start()
    {
        // Initialize variables 
        this.player = GetComponent<Player>();
        this.playerRigidBody = GetComponent<Rigidbody2D>();
        this.playerSpriteRenderer = GetComponent<SpriteRenderer>();
        this.playerAnimatorMovement = GetComponent<Animator>(); 
        this.playerLogicMovement = GetComponent<PlayerLogicMovement>();

        this.playerStateMovement = new PlayerStateMovement(this.playerLogicMovement, this.playerRigidBody);
    }

    void Update()
    {
        this.state = this.playerStateMovement.GetPlayerStateMovement();

        if (this.playerStateMovement.getRight())
        {
            this.playerSpriteRenderer.flipX = false;
        }
        else
        {
            this.playerSpriteRenderer.flipX = true;
        }
        
        this.playerAnimatorMovement.SetInteger(STATE_ANIM, state);
    }

}
