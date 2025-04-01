using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    //Assigned a player object to follow
    public GameObject player;

    //camera bounds
    private float cameraXBound = 3.72f;
    private float cameraYBound = 9f;

    // Update is called once per frame
    // Updates the cameras position each frame
    void Update()
    {
        CameraPosition();
    }


    // Method to update the cameras position
    // X position ends up being locked
    // Y position follows the player after a certain height
    private void CameraPosition()
    {
        if (player.transform.position.y > cameraYBound)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

            if (this.name == "Player 1 Camera")
            {
                if (transform.position.x > -cameraXBound)
                    transform.position = new Vector3(-5.15f, transform.position.y, transform.position.z);
            }
            else if (this.name == "Player 2 Camera")
            {
                if (transform.position.x < cameraXBound)
                    transform.position = new Vector3(6.5f, transform.position.y, transform.position.z);
            }
        }        
    }
}
