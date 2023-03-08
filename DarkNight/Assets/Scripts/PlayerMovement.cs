using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private LayerMask jumpableGround;

    private Rigidbody2D playerBody;
    private BoxCollider2D playerColl;
    private SpriteRenderer playerSprite;
    private Animator playerAnim;

    private float dirX;
    private string stateMovement = "stateMovement";
    private string terrainTag = "Terrain";
    private int doubleJump = 0;
    private bool isGrounded = true;

    // [SerializeField] = Nos permite ver estos parametros en el inspector
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { iddle, running, jumping, falling }

    // Start is called before the first frame update
    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        InputMovement();
        UpdateAnimationState();
    }

    void InputMovement() 
    {
        // Left = -1 and Right = +1. If we use a joystick we get values in between.
        dirX = Input.GetAxisRaw("Horizontal");
        playerBody.velocity = new Vector2(dirX * moveSpeed, playerBody.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);

            doubleJump++;
            if (doubleJump >= 2)
            {
                isGrounded = false;
                doubleJump = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(terrainTag))
        {
            isGrounded = true;
        }
    }

    private void UpdateAnimationState()
    {

        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            playerSprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            playerSprite.flipX = true;
        }
        else
        {
            state = MovementState.iddle;
        }

        if (playerBody.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (playerBody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        playerAnim.SetInteger(stateMovement, (int) state);
    }
}
