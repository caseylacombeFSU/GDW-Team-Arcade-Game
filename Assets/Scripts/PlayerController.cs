using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    private float speed = 5.0f;
    private float jumpForce = 200.0f;

    private float horizontalInput;
    private float xBound = 25.0f;

    private bool inputType;
    public bool isGrounded;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        inputType = this.name == "Player 1";

        Cursor.visible = false;
        isGrounded = true;
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

    }

    private void CheckPlayerPosition()
    {
        if(inputType) 
        {
            if (transform.position.x < -xBound)
                transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
            if (transform.position.x > -1)
                transform.position = new Vector3(-1, transform.position.y, transform.position.z);
        }
        else 
        {
            if (transform.position.x < 1) 
                transform.position = new Vector3(1, transform.position.y, transform.position.z);
            if (transform.position.x > xBound)
                transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        

    }

    private void CheckJump()
    {
        if(inputType)
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
        if(inputType)
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
        isGrounded = true;
    }


}
