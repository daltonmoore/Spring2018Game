using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxGrabVer2 : MonoBehaviour
{
    playerControllerBoxTester p;
    Rigidbody2D rigid;

    // Use this for initialization
    void Start ()
    {
        p = GetComponentInParent<playerControllerBoxTester>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "InteractableObject")
        { 
            rigid = collision.gameObject.GetComponent<Rigidbody2D>();
            p.setGrab(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (p.grabbed)
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        else
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "InteractableObject")
        {
            p.setGrab(null);    
        }
    }
}
