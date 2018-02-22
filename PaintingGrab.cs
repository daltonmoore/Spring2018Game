using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingGrab : MonoBehaviour
{
    PlayerControllerVer3 p;

    // Use this for initialization
    void Start ()
    {
        	p = GetComponentInParent<PlayerControllerVer3>();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "InteractableObject" && !p.getCanGrab())
        {
            p.setCanGrab(true);
            print("CAN GRAB");
            p.setPainting(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        p.setCanGrab(false);
        print("CAN NOT GRAB");
    }
}
