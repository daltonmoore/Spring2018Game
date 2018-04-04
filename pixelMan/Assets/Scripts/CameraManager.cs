using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class CameraManager : MonoBehaviour
{
    public Camera cam;
    public GameObject playerLoc;
    bool xLockedRight, xLockedLeft;
    
    void Update()
    {
        if (Mathf.Abs(playerLoc.transform.position.x) >= 5.67f || playerLoc.transform.position.y <= -3.16f)
        {
            if (playerLoc.transform.position.x >= 5.67f)
            {
                cam.transform.position = new Vector3(5.67f, playerLoc.transform.position.y, -1f);
                xLockedRight = true;
            }
            if (playerLoc.transform.position.x <= -5.67f)
            {
                cam.transform.position = new Vector3(-5.67f, playerLoc.transform.position.y, -1f);
                xLockedLeft = true;
            }
            if (playerLoc.transform.position.x < 5.67f && playerLoc.transform.position.x > -5.67f)
            {
                xLockedRight = false;
                xLockedLeft = false;
            }
            if (xLockedLeft || xLockedRight)
            {
                if (xLockedRight)
                {
                    cam.transform.position = new Vector3(5.67f, -3.16f, -1f);
                }
                if (xLockedLeft)
                {
                    cam.transform.position = new Vector3(-5.67f, -3.16f, -1f);
                }
            }
            else
                cam.transform.position = new Vector3(playerLoc.transform.position.x, -3.16f, -1f);
        }
        else
        {
            cam.transform.position = playerLoc.transform.position + new Vector3(0, 0, -1f);
        }
    }
}

