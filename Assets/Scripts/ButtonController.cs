using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject door;
    private bool triggerable = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && triggerable)
        {
            door.transform.position = door.transform.position + new Vector3(0, 3.5f, 0);
            triggerable = false;
        }
    }
    
}
