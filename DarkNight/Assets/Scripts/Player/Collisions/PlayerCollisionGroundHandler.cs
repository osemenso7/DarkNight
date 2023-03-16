using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionGroundHandler : MonoBehaviour, IPlayerCollisionHandler
{

    // PLayer observer
    private IPlayerCollisionObserver playerObserver;

    // Ground collision control variables
    private string TERRAIN_TAG = "Terrain";


    public void HandlePlayerCollision()
    {
        this.playerObserver.SetIsGrounded();
    }


    private void OnCollisionEnter2D(Collision2D collision) 
    {
        //Check if the collision is with terrain
        if (collision.gameObject.CompareTag(this.TERRAIN_TAG))
        {
            this.HandlePlayerCollision();
        }
    }

    public void SetPlayerCollisionObserver(IPlayerCollisionObserver playerObserver)
    {
        this.playerObserver = playerObserver;
    }
}
