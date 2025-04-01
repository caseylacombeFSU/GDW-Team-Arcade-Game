using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Rigidbody for the player and a text mesh UI for the player's health
    private Rigidbody playerRb;
    public TextMeshProUGUI playerHealth;
    
    // GameManager to control game end conditions
    private GameManager gameManager;

    // Speed and jump force for the player
    private float speed = 5.0f;
    private float jumpForce = 400.0f;

    // User input for the horizontal movement of the player and an X bound for their movement
    private float horizontalInput;
    private float xBound = 13.45f;

    // bool to determine input type of the player and a bool to check if the player is grounded so that they can jump again
    private bool inputType;
    public bool isGrounded;

    // Int to track the players health
    public int health = 2;


    // Start is called before the first frame update
    void Start()
    {
        // Initializes the players rigidbody
        // Initializes the input type, true if player 1 and false if player 2
        playerRb = GetComponent<Rigidbody>();
        inputType = this.name == "Player 1";

        // Disables the cursor and intializes isGrounded as true
        Cursor.visible = false;
        isGrounded = true;

        // Sets the players health in the UI
        playerHealth.text = "♥♥";

        // Initializes the game manager object
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    // Checks if the player jumps, moves, and is in bounds each frame
    // Checks if the quit button (esc) is hit and checks if the game complete bool is true in the game manager
    void Update()
    {

        CheckHorizontalMovement();

        CheckJump();

        CheckPlayerPosition();

        // Quits the game if ESC is hit
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

        // If gameComplete is true then movement and jumping is stopped for the player
        if (gameManager.gameComplete)
        {
            isGrounded = false;
            speed = 0;
        }

    }

    // Method to check the players position to keep them in bounds
    private void CheckPlayerPosition()
    {
        if (inputType)
        {
            if (transform.position.x < -xBound)
                transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
            if (transform.position.x > -0.75F)
                transform.position = new Vector3(-0.75F, transform.position.y, transform.position.z);
        }
        else
        {
            if (transform.position.x < 0.75F)
                transform.position = new Vector3(0.75F, transform.position.y, transform.position.z);
            if (transform.position.x > xBound)
                transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }


    }

    // Method to check if a player has hit the jump key and to make them jump if so
    private void CheckJump()
    {
        if (inputType)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4) && isGrounded)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }

    // Checks if the cooresponding player has inputted movement
    private void CheckHorizontalMovement()
    {
        if (inputType)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal2");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        }
    }

    // Checks if the player has collided with the ground or a hazard object
    private void OnCollisionEnter(Collision collision)
    {
        // If ground then isGrounded is set to true so that the player can jump again
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        // Else if its a hazard it checks the players current health and decrements it accordingly or calls the gameOver method in the game manager if their health reaches 0
        else if (collision.gameObject.CompareTag("Hazard") && health > 1)
        {
            playerHealth.text = "♥";
            health--;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Hazard") && health < 2)
        {
            playerHealth.text = "";
            health--;
            Destroy(collision.gameObject);
            gameManager.GameOver();
            
        }

    }

}