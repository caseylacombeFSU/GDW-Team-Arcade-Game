using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    //assigned a door object to control
    public GameObject door;
    //makes it so that the button is only triggered once
    private bool triggerable = true;
    //game manager object to determine the win condition
    private GameManager gameManager;
    //vector3 for the door movement
    private Vector3 movement = new Vector3(0, 0, 20);

    // Start is called before the first frame update
    // Initializes the game manager object
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Method for when a button is hit
    public void OnTriggerEnter(Collider other)
    {
        //If the button is one of the final buttons with a wincon assigned door then it can be triggered repeatedly 
        //Each trigger will increment a wincon int in the game manager object, once the target number is reached the game is won
        if (door.CompareTag("Wincon"))
        {
            gameManager.WinConIncrement();
        }
        //generic button interaction, once triggered the button can no longer be triggered and it moves its assigned door
        else if (other.tag == "Player" && triggerable)
        {
            door.transform.position = door.transform.position + movement;
            triggerable = false;

        }
        

    }

    // Method for when a button is stepped off of
    // If a final button is stepped off of then the win con int in the game manager object is decremented
    // this makes it so that both buttons must be stepped on in order for the game to be won
    public void OnTriggerExit(Collider other)
    {
        if (door.CompareTag("Wincon"))
        {
            gameManager.WinConDecrement();
        }
    }


}
