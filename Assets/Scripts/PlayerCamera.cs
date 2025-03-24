using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 0, 10);
    private float cameraXBound = 3.72f;

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
        transform.position = player.transform.position - offset;
        
        if(this.name == "Player 1 Camera")
        {
            if (transform.position.x > -cameraXBound)
                transform.position = new Vector3(-cameraXBound, transform.position.y, transform.position.z);
        }
        else if(this.name == "Player 2 Camera")
        {
            if (transform.position.x < cameraXBound)
                transform.position = new Vector3(cameraXBound, transform.position.y, transform.position.z);
        }
        
    }
}
