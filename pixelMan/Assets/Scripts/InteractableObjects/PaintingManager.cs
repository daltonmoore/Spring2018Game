using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingManager : MonoBehaviour
{
    Painting[] paintings;
    PlayerControllerVer2 player;

	// Use this for initialization
	void Start ()
    {
        GameObject[] tempFrames = GameObject.FindGameObjectsWithTag("Painting");
        GameObject[] tempGrabs = GameObject.FindGameObjectsWithTag("PaintingGrab");
        paintings = new Painting[tempFrames.Length];

        for (int i = 0; i < tempFrames.Length; i++)
        {
            paintings[i] = new Painting(tempFrames[i], tempGrabs[i]);
            print(paintings[i]);
        }
        player = GameObject.Find("Player").GetComponent<PlayerControllerVer2>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < paintings.Length; i++)
        {
            
        }
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
}
