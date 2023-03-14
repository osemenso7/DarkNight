using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsPlayerCollisionGround : MonoBehaviour, IObserverPlayerCollision
{

    private string TERRAIN_TAG = "terrain";
    private bool isGrounded = true;

    public ObsPlayerCollisionGround() { }

    public bool GetPlayerCollision()
    {
        return this.isGrounded;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag(this.TERRAIN_TAG))
        {
            isGrounded = true;
        }
    }
}
