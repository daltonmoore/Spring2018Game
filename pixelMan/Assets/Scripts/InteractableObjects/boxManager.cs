using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxManager : MonoBehaviour
{
    //let's just use boxmanager to create a box grid

    //GameObject[] boxes;
    //Box[] boxStructs;

    private void Start()
    {

        /*
        boxes = GameObject.FindGameObjectsWithTag("InteractableBox");
        boxStructs = new Box[boxes.Length];
        for (int k = 0; k < boxes.Length; k++)
        {
            List<boxGrab> temp = new List<boxGrab>();
            foreach (var i in boxes[k].GetComponentsInChildren<boxGrab>())
            {
                temp.Add(i);
            }

            boxStructs[k] = new Box(boxes[k], temp[0], temp[1], temp[2], temp[3]);
        }

        foreach (var item in boxStructs)
        {
            print(item.parentBox);
        }
        */
    }

    // Update is called once per frame
    void Update ()
    {


        /*
        boxGrab bg = null;
        if (boxes == null)
            return;
        else
        {
            int counter = 0;
            
            foreach (var item in boxStructs)
            {
                foreach (var i in item.getBoxGrabs())
                {
                    i.onlyOne = true;
                }
                if (item.left.canBeGrabbed)
                {
                    counter++;
                    bg = item.left;
                }
                else if (item.right.canBeGrabbed)
                {
                    counter++;
                    bg = item.right;
                }
                else if (item.up.canBeGrabbed)
                {
                    counter++;
                    bg = item.up;
                }
                else if (item.down.canBeGrabbed)
                {
                    counter++;
                    bg = item.down;
                }
            }
            if (bg != null)
            {
                if (counter == 1)
                    bg.onlyOne = true;
                else
                    bg.onlyOne = false;
                print(bg.transform.parent.name);
                print(bg.onlyOne);
            }
        }*/
	}

    /*
    public struct Box
    {
        public GameObject parentBox;
        public boxGrab left, right, down, up;

        public Box(GameObject b, boxGrab l, boxGrab u, boxGrab r, boxGrab d)
        {
            parentBox = b;
            left = l;
            right = r;
            down = d;
            up = u;
        }

        public boxGrab[] getBoxGrabs()
        {
            boxGrab[] bg = new boxGrab[4];
            bg[0] = left;
            bg[1] = up;
            bg[2] = right;
            bg[3] = down;
            return bg;
        }
    }*/
}
