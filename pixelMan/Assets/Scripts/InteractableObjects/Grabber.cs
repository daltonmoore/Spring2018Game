using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    GameObject painting;
<<<<<<< HEAD
    PaintingSlot paintingSlot;
    PlayerControllerVer2 p;
    bool playerCanGrab, playerHasPainting = false;
=======
    PlayerControllerVer2 p;
>>>>>>> 9c3150192ec05fb7801886791c5f92acffd2f6fd

    // Use this for initialization
    void Start ()
    {
        	p = GetComponentInParent<PlayerControllerVer2>();
    }
	
	// Update is called once per frame
	void Update ()
    {
<<<<<<< HEAD
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
=======

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("entered");
        if (other.tag == "PaintingGrab")
        {
            p.canGrab = true;
>>>>>>> 9c3150192ec05fb7801886791c5f92acffd2f6fd
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
<<<<<<< HEAD
        playerCanGrab = false;
=======
        p.canGrab = false;
>>>>>>> 9c3150192ec05fb7801886791c5f92acffd2f6fd
    }
}
