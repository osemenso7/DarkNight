using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputKeyboardMovement : IPlayerInputMovement
{

    private float dirX;

    public PlayerInputKeyboardMovement() {  }

    // Get movement depending on keyboard input
    public int GetPlayerMovement()
    {
        int action = 0;

        // Get direction in X axis
        this.dirX = Input.GetAxisRaw("Horizontal");

        // Control button jump
        if (Input.GetButtonDown("Jump"))
        {
            action = 1;
        }

        // Control button dash
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            action = 2;
        }

        return action;
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
