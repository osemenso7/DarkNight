using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashController
{

    // Player components
    Rigidbody2D playerRigidBody;

    // Dash control variables
    private float startGravity;
    private float dashCD;

    private bool isDashable = true;
    private bool canMove = true;
    private float dashTime = 0.25f;


    public DashController() {  }

    public DashController(Rigidbody2D playerRigidBody, float dashCD) 
    {
        this.playerRigidBody = playerRigidBody;
        this.startGravity = this.playerRigidBody.gravityScale;
        this.dashCD = dashCD;
    }


    public IEnumerator DashControl()
    {
        // Make sure the dash is complete and wait for its cooldown
        this.isDashable = false;
        this.canMove = false;

        // With gravity = 0 we achieve a straight dash
        this.playerRigidBody.gravityScale = 0;

        // Wait until the dash ends
        yield return new WaitForSeconds(this.dashTime);

        this.playerRigidBody.gravityScale = this.startGravity;
        this.canMove = true;
    }

    public IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(this.dashCD);
        this.isDashable = true;
    }


    public bool GetIsDashable()
    {
        return this.isDashable;
    }

    public bool GetCanMove()
    {
        return this.canMove;
    }
}
