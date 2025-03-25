using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 0, 10);
    private float cameraXBound = 3.72f;
    private float cameraYBound = 6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraPosition();
    }



    private void CameraPosition()
    {
        if (player.transform.position.y > cameraYBound)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z) - offset;

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
