using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    GameObject painting;
    PaintingSlot paintingSlot;
    bool inPaintingTrigger, hasPainting;
    Sprite paintingSprite;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        grab();
    }

    void grab()
    {
        if(Input.GetKeyDown(KeyCode.E) && inPaintingTrigger && !hasPainting)//you are in range to grab the painting and you press the grab button and you don't have a painting
        {
            painting.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.E)) //you press e 
        {
            print("cannot grab");
        }
    }

    void placer()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PaintingGrab")
        {
            inPaintingTrigger = true;
            painting = other.transform.parent.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PaintingGrab")
        {
            inPaintingTrigger = false;
        }
    }   
}