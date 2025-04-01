using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject door;
    private bool triggerable = true;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (door.CompareTag("Wincon"))
        {
            gameManager.WinConIncrement();
        }
        else if (other.tag == "Player" && triggerable)
        {
            door.transform.position = door.transform.position + new Vector3(0, 3.5f, 0);
            triggerable = false;

        }
        

    }

    public void OnTriggerExit(Collider other)
    {
        if (door.CompareTag("Wincon"))
        {
            gameManager.WinConDecrement();
        }
    }


}
