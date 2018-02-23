using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerControllerVer3 : MonoBehaviour
{
    bool canGrab, grabbed;
    bool inPlace0, inPlace1, inPlace2; //player is in front of locations to place paintings on wall
    float x, y;
    GameObject painting;
    Transform paintingSlot0, paintingSlot1, paintingSlot2;

    // Use this for initialization
    void Start ()
    {
        try
        {
            paintingSlot0 = GameObject.Find("PaintingSlot0").transform;
            paintingSlot1 = GameObject.Find("PaintingSlot1").transform;
            paintingSlot2 = GameObject.Find("PaintingSlot2").transform;
        }
        catch(Exception e)
        {
            print(e.StackTrace);
            print("Cannot find painting slots");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
        y = Input.GetAxis("Vertical") * Time.fixedDeltaTime;
        transform.position += new Vector3(x, y);

        if (Input.GetKeyDown(KeyCode.E) && painting != null)
        {
            if (grabbed == false)
            {
                painting.SetActive(false);
            }
            else
                placePainting();
            grabbed = !grabbed;
        }
        rotateGrabber(x,y);
    }

    public void setCanGrab(bool canGrab)
    {
        this.canGrab = canGrab;
    }

    public bool getCanGrab()
    {
        return canGrab;
    }

    public void setInPlace(int i)
    {
        switch (i)
        {
            case 0:
                inPlace0 = true;
                inPlace1 = false;
                inPlace2 = false;
                break;
            case 1:
                inPlace0 = false;
                inPlace1 = true;
                inPlace2 = false;
                break;
            case 2:
                inPlace0 = false;
                inPlace1 = false;
                inPlace2 = true;
                break;
        }
    }

    void rotateGrabber(float x, float y)
    {
        if (!grabbed)
        {
            if (x > 0)
                transform.eulerAngles = new Vector3(0, 0, 0);
            else if (x < 0)
                transform.eulerAngles = new Vector3(0, 0, 180);
            if (y > 0)
                transform.eulerAngles = new Vector3(0, 0, 90);
            else if (y < 0)
                transform.eulerAngles = new Vector3(0, 0, -90);
        }
    }

    public void setPainting(GameObject painting)
    {
        this.painting = painting;
    }

    void placePainting()
    {
        if (inPlace0)
            painting.transform.position = paintingSlot0.position;
        else if (inPlace1)
            painting.transform.position = paintingSlot1.position;
        else if (inPlace2)
            painting.transform.position = paintingSlot2.position;
        painting.SetActive(true);
    }
}
