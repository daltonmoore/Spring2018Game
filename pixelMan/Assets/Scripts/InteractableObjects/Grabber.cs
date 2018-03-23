using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    string currentPaintingSlotID;
    PaintingSlot currentPaintingSlot;
    GameObject painting;
    GameObject paintingCodeSlot;
    bool playerInGrabOrPlaceTrigger, playerHasPainting = false;
    bool playerInCodeTrigger;
    bool paintingCodeOneCorrect, paintingCodeTwoCorrect, paintingCodeThreeCorrect;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkGrab();
    }


    float grabTimer;
    void checkGrab()
    {
        if (grabTimer + 1 < Time.time)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (playerInGrabOrPlaceTrigger)
                {
                    grabTimer = Time.time;
                    if (!playerHasPainting)//you don't have a painting
                    {
                        if (currentPaintingSlot.hasPainting())
                        {
                            playerHasPainting = true;
                            painting.SetActive(false);
                        }
                    }
                    else //you have a painting
                    {
                        if (currentPaintingSlot.hasPainting())
                        {
                            print("Slot already has painting");
                        }
                        placer();
                    }
                }
                if (playerInCodeTrigger)
                {
                    grabTimer = Time.time;
                    if(!playerHasPainting)
                    {
                        print("Dude get a painting");
                        return;
                    }
                    else if(paintingCodeSlot.has)
                    {
                        painting.transform.position = paintingCodeSlot.transform.position;
                        painting.transform.localScale = new Vector3(.05f,.05f);
                        painting.SetActive(true);
                        playerHasPainting = false;
                    }
                }
            }
        }
    }

    void placer()
    {
        if (currentPaintingSlotID == painting.name.Substring(8) && !currentPaintingSlot.hasPainting())//substring(8) is last two chars of the string PaintingXX
        {
            print("That's the right painting");
            painting.SetActive(true);
            playerHasPainting = false;
        }
        else
        {
            print("Your painting can't go into that slot");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PaintingGrab")//grabtrigger tells you that you are in front of the painting slot
        {
            playerInGrabOrPlaceTrigger = true;
            currentPaintingSlot = other.gameObject.transform.parent.gameObject.GetComponent<PaintingSlot>();
            currentPaintingSlotID = currentPaintingSlot.name;

            if (!playerHasPainting)
            {
                painting = GameObject.Find("Painting" + currentPaintingSlotID);
            }
        }

        if(other.tag == "PaintingCodeGrab")
        {
            playerInCodeTrigger = true;
            paintingCodeSlot = other.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PaintingGrab" || other.tag == "PaintingCodeGrab")
        {
            playerInGrabOrPlaceTrigger = false;
            playerInCodeTrigger = false;
        }
    }
       
}
