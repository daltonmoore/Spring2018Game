﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public bool catDungeonDialog;
    string currentPaintingSlotID;
    PaintingSlot currentPaintingSlot;
    GameObject painting;
    GameObject paintingCodeSlot;
    bool playerInGrabOrPlaceTrigger, playerHasPainting = false;
    bool playerInCodeTrigger;
    bool paintingCodeOneCorrect, paintingCodeTwoCorrect, paintingCodeThreeCorrect;
    PlayerControllerVer2 controller;
    int currentCodeSlot;
    public CanvasController canvas;

    GameObject[] paintingBuffer = new GameObject[3];

    // Use this for initialization
    void Start()
    {
        controller = GetComponentInParent<PlayerControllerVer2>();
    }

    // Update is called once per frame
    void Update()
    {
        //checkGrab();
    }

    public bool getPlayerHasPainting()
    {
        return playerHasPainting;
    }

    float grabTimer;
    public void checkGrab()
    {
        if (grabTimer + 1 < Time.time)
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
                        controller.NextToPainting = false;

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
                print(painting);
                grabTimer = Time.time;
                if (currentPaintingSlot.hasPainting())
                {
                    playerHasPainting = true;
                    painting.SetActive(false);
                }
                else if (!currentPaintingSlot.hasPainting() && playerHasPainting)
                {
                    painting.transform.position = paintingCodeSlot.transform.position;
                    paintingBuffer[currentCodeSlot-1] = painting;
                    //painting.transform.localScale = new Vector3(.05f,.05f);
                    painting.SetActive(true);
                    playerHasPainting = false;
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
            painting.transform.position = currentPaintingSlot.transform.position;
            playerHasPainting = false;
        }
        else
        {
            print("Your painting can't go into that slot");
            canvas.CanNotPlacePaintingPopUp.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "CatDialog")
        {
            catDungeonDialog = true;
        }
        if (other.tag == "PaintingGrab")//grabtrigger tells you that you are in front of the painting slot
        {
            playerInGrabOrPlaceTrigger = true;
            currentPaintingSlot = other.gameObject.transform.parent.gameObject.GetComponent<PaintingSlot>();
            currentPaintingSlotID = currentPaintingSlot.name;


            controller.NextToPainting = true;
            //push text from painting slot into character controller so they can read it
            if (currentPaintingSlot.PaintingText != null)
            {
                controller.SetPaintingText(currentPaintingSlot.PaintingText);
            }
            else
            {
                print("missing text");
                controller.missingText = true;
            }


            if (!playerHasPainting)
            {
                painting = GameObject.Find("Painting" + currentPaintingSlotID);
            }

            canvas.inspectPopUp.SetActive(true);
        }

        if (other.tag == "PaintingCodeGrab")
        {
            playerInCodeTrigger = true;
            paintingCodeSlot = other.transform.parent.gameObject;
            currentPaintingSlot = other.gameObject.transform.parent.gameObject.GetComponent<PaintingSlot>();
            currentPaintingSlotID = currentPaintingSlot.name;
            int.TryParse(currentPaintingSlotID.Substring(16), out currentCodeSlot);
            print(currentCodeSlot);
            if (!playerHasPainting)
                painting = paintingBuffer[currentCodeSlot-1];
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PaintingGrab" || other.tag == "PaintingCodeGrab")
        {
            playerInGrabOrPlaceTrigger = false;
            playerInCodeTrigger = false;
            controller.NextToPainting = false;
            controller.ClearPaintingText();
            canvas.inspectPopUp.SetActive(false);
        }
    }
}