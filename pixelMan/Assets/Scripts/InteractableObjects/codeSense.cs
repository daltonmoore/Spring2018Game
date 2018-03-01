using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeSense : MonoBehaviour
{
    public PlayerControllerVer3 player;
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
        checkTile(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

    void checkTile(GameObject o)
    {
        switch (name)
        {
            case "InFrontOfSlot0":
                player.setInPlace(0);
                break;
            case "InFrontOfSlot1":
                player.setInPlace(1);
                break;
            case "InFrontOfSlot2":
                player.setInPlace(2);
                break;
        }
    }
}
