using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    GameObject painting;
    PlayerControllerVer2 p;

    // Use this for initialization
    void Start ()
    {
        	p = GetComponentInParent<PlayerControllerVer2>();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("entered");
        if (other.tag == "PaintingGrab")
        {
            p.canGrab = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        p.canGrab = false;
    }
}
