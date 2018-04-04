using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class CameraManager : MonoBehaviour
{
    public Camera cam;
    public GameObject playerLoc;
    bool xLocked;
    
    void Update()
    {
        if (Mathf.Abs(playerLoc.transform.position.x) >= 5.57f || playerLoc.transform.position.y <= -3.16f)
        {
            if (playerLoc.transform.position.x >= 5.57f)
            {
                cam.transform.position = new Vector3(5.57f, playerLoc.transform.position.y, -1f);
                xLocked = true;
            }
            if (playerLoc.transform.position.y <= -3.16f)
            {
                if (xLocked)
                    cam.transform.position = new Vector3(5.57f, -3.16f, -1f);
                else
                    cam.transform.position = new Vector3(playerLoc.transform.position.x, -3.16f, -1f);
            }
        }
        else
        {
            cam.transform.position = playerLoc.transform.position + new Vector3(0, 0, -1f);
        }
    }
}

