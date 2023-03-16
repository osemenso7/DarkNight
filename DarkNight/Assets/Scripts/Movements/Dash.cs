using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour, IMovement
{

    // Player components
    private Player player;
    private Rigidbody2D playerRigidBody;
    private SpriteRenderer playerSpriteRenderer;

    // Dash stats
    private DashController dashControl;
    

    private void Start()
    {  
        this.player = GetComponent<Player>();
        this.playerRigidBody = GetComponent<Rigidbody2D>();
        this.playerSpriteRenderer = GetComponent<SpriteRenderer>();

        this.dashControl = new DashController(this.playerRigidBody, this.player.GetDashCD());
    }


    // Make dash
    public void MakeMove()
    {
        if (this.playerSpriteRenderer.flipX == false)
        {
            this.playerRigidBody.velocity = new Vector2(this.player.GetDashForce(), 0);
        }
        else
        {
            this.playerRigidBody.velocity = new Vector2(-this.player.GetDashForce(), 0);
        }

        StartCoroutine(this.dashControl.DashControl());
        StartCoroutine(this.dashControl.DashCooldown());
    }

    // Getter
    public DashController GetDashController()
    {
        return this.dashControl;
    }

}
