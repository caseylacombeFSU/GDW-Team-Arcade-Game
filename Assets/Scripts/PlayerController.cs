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

        //
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        CheckHorizontalMovement();

        CheckJump();

        CheckPlayerPosition();

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (gameManager.gameComplete)
        {
            isGrounded = false;
            speed = 0;
        }

    }

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
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