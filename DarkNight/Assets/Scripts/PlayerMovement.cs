using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Serialized elements
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float dashForce = 20f;
    [SerializeField] private float dashCD = 4f;

    // Components
    private Rigidbody2D playerBody;
    private BoxCollider2D playerColl;
    private SpriteRenderer playerSprite;
    private Animator playerAnim;

    // Name of Tags, Layers, etc...
    private string stateMovement = "stateMovement";
    private string terrainTag = "Terrain";

    // Not initiated variables
    private float dirX;
    private float startGravity;

    // Variables
    private float dashDuration = 0.25f;
    private int doubleJump = 0;
    private bool isGrounded = true;
    private bool isDashable = true;
    private bool canMove = true;
    private bool airDash = true;

    private enum MovementState { iddle, running, jumping, falling }

    // Start is called before the first frame update
    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();

        startGravity = playerBody.gravityScale;
    }

    // Update is called once per frame
    private void Update()
    {

        if (canMove)
        {
            InputMovement();
            UpdateAnimationState();
        }

    }

    void InputMovement() 
    {
        // Left = -1 and Right = +1. If we use a joystick we get values in between.
        dirX = Input.GetAxisRaw("Horizontal");
        playerBody.velocity = new Vector2(dirX * moveSpeed, playerBody.velocity.y);

        // Control input and how many jumps can do the player 
        if (Input.GetButtonDown("Jump") && (isGrounded || doubleJump < 2))
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpForce);

            isGrounded = false;
            doubleJump++;

        }

        // Control input and how many rolls can do in the air.
        if (Input.GetKeyDown(KeyCode.LeftControl) && isDashable)
        {
            if (isGrounded)
            {
                StartCoroutine(Dash());
            }
            else
            {
                if (airDash)
                {
                    StartCoroutine(Dash());
                    airDash = false;
                }
            }
        }
    }

    // Control when the player touches the terrain
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(terrainTag))
        {
            isGrounded = true;
            airDash = true;
            doubleJump = 0;
        }
    }

    /* Another method to control if the player touches the ground
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }*/

    // Control animations of the player
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

    // Logic to do a dash
    private IEnumerator Dash()
    {

        isDashable = false;
        canMove = false;
        playerBody.gravityScale = 0;

        // Check Direction of the dash
        if (playerSprite.flipX == false)
        {
            playerBody.velocity = new Vector2(dashForce, 0);
        }
        else
        {
            playerBody.velocity = new Vector2(-dashForce, 0);
        }

        // Dash animation
        playerAnim.SetTrigger("dash");

        // Start couldown of the dash
        StartCoroutine(DashCD());

        yield return new WaitForSeconds(dashDuration);

        playerBody.gravityScale = startGravity;
        canMove = true;
    }

    // Couldown of the dash
    private IEnumerator DashCD()
    {

        yield return new WaitForSeconds(dashCD);

        isDashable = true;
    }
}
