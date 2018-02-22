using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeSense : MonoBehaviour
{
    public bool c1, c2, c3, c4;
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (c1 && c2 && c3 && c4)
            print("All are correct");
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        checkTile(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (c1 && collision.name == "paintingone")
            c1 = false;
        else if (c2 && collision.name == "paintingtwo")
            c2 = false;
        else if (c3 && collision.name == "paintingthree")
            c3 = false;
        else if (c4 && collision.name == "paintingfour")
            c4 = false;
    }

    void checkTile(GameObject o)
    {
        if (name == "tileone")
        {
            if (o.name == "paintingone")
                c1 = true;
        }
        else if (name == "tiletwo")
        {
            print(o.name);
            if (o.name == "paintingtwo")
                c2 = true;
        }
        else if (name == "tilethree")
        {
            if (o.name == "paintingthree")
                c3 = true;
        }
        else if (name == "tilefour")
        {
            if (o.name == "paintingfour")
                c4 = true;
        }
    }
}
