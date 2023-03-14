using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputKeyboardMovement : IPlayerInputMovement
{
    
    private int action;
    private float dirX;


    public PlayerInputKeyboardMovement() {  }
    

    // Get movement depending on keyboard input
    public int GetPlayerMovement()
    {
        this.action = 0;

        // Get direction in X axis
        this.dirX = Input.GetAxisRaw("Horizontal");

        // Control button jump
        if (Input.GetButtonDown("Jump"))
        {
            this.action = 1;
        }

        // Control button dash
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            this.action = 2;
        }

        return this.action;
    }


    //Getter
    public float GetDirX()
    {
        return this.dirX;
    }

    // Setter
    public void SetDirX(float dirX)
    {
        this.dirX = dirX;
    }

}
