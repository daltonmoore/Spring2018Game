using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingManager : MonoBehaviour
{
    Painting[] paintings;
    Grabber playerGrabberHand;

	void Start ()
    {
        try
        {
            playerGrabberHand = GameObject.Find("Grabber").GetComponent<Grabber>();


            GameObject[] tempFrames = GameObject.FindGameObjectsWithTag("Painting");
            GameObject[] tempGrabs = GameObject.FindGameObjectsWithTag("PaintingGrab");
            paintings = new Painting[tempFrames.Length];

            for (int i = 0; i < tempFrames.Length; i++)
            {
                paintings[i] = new Painting(tempFrames[i], tempGrabs[i]);
            }
        }
        catch (System.Exception e)
        {
            print(e.StackTrace);
        }
	}

    float timer = 0;
	void Update ()
    {
        if (timer + 1 < Time.time)
        {
            timer = Time.time;
            for (int i = 0; i < paintings.Length; i++)
            {
                //print("Position of "+ paintings[i].getPaintingFrame().name + " is " + paintings[i].getPaintingFrame().transform.position);
            }

            //print(playerGrabberHand.getPlayerHasGrabbed());
        }

        /*if (playerGrabberHand.getPlayerHasGrabbed())
        {
            print("You have grabbed " + playerGrabberHand.getPainting());

        }*/
	}
}

struct Painting
{
    GameObject paintingFrame, paintingGrabSlot;

    public Painting(GameObject pf, GameObject pg)
    {
        paintingFrame = pf;
        paintingGrabSlot = pg;
    }

    public GameObject getPaintingFrame()
    {
        return paintingFrame;
    }

    public GameObject getPaintGrabSlot()
    {
        return paintingGrabSlot;
    }
}
