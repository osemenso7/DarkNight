using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private float playerJump = 10f;

    private float dirX;
    private float dirY;

    private Rigidbody2D playerBody;
    private SpriteRenderer playerSprite;
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
        AnimationPlayer();
    }

    void InputPlayer()
    {

        // Get direction of the X depending on the input
        dirX = Input.GetAxisRaw("Horizontal");

        if (dirX > 0f)
        {
            transform.position += new Vector3(dirX, 0, 0) * playerSpeed * Time.deltaTime; 
            playerSprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            transform.position += new Vector3(dirX, 0, 0) * playerSpeed * Time.deltaTime;
            playerSprite.flipX = true; 
        }

        // Get direction of the Y depending on the input
        if (Input.GetButtonDown("Jump"))
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, playerJump);
        }

    }

    void AnimationPlayer()
    {

        

    }
}
