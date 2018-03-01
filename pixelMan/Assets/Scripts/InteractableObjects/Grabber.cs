using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    GameObject painting;
    PaintingSlot paintingSlot;
    PlayerControllerVer2 p;
    bool playerCanGrab, playerHasPainting = false;

    // Use this for initialization
    void Start ()
    {
        	p = GetComponentInParent<PlayerControllerVer2>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        checkGrab();
	}

    void checkGrab()
    {
        if (!playerHasPainting)//you don't have a painting
        {
            if (Input.GetKeyDown(KeyCode.E) && playerCanGrab)
            {
                //if slot has painting grab it
                if (paintingSlot.hasPainting())
                {
                    playerHasPainting = true;
                    painting.SetActive(false);
                    paintingSlot.setPaintingPresent(false);
                }
            }
        }
        else //you have a painting
        {
            if(Input.GetKeyDown(KeyCode.E))
                print("You cannot grab because you already have a painting");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PaintingGrab" && !playerHasPainting)
        {
            playerCanGrab = true;
            painting = other.transform.parent.gameObject;
            paintingSlot = painting.transform.parent.GetComponent<PaintingSlot>();
            print(paintingSlot.name);
            print(painting.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerCanGrab = false;
    }
}
