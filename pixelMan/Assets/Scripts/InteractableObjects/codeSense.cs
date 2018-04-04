using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeSense : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Painting01" && name == "PaintingCodeSlot1")
            print("Yeah thats the right painting for slot 1");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
