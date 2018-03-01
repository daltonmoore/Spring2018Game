using UnityEngine;
using System.Collections;

public class boxGrab : MonoBehaviour
{
    //the box itself is handling all grabbing interactions, instead of the player
    GameObject box;
    playerControllerBoxTester p;
    public bool canBeGrabbed, grabbed, onlyOne = true;

    void Start()
    {
        box = transform.parent.gameObject;
        p = GameObject.Find("Player").GetComponent<playerControllerBoxTester>();
    }

    void Update()
    {
        bool grab = Input.GetKeyDown(KeyCode.E);
        if (grab && canBeGrabbed && !grabbed)
        {
            grabbed = true;
            //p.holding = true;
        }
        else if(grabbed && grab)
        {
            grabbed = false;
            //p.holding = false;
        }

        if(grabbed)
        {
            if(name == "TriggerLeft")
                box.transform.position = p.gameObject.transform.position + new Vector3(.2f,0);
            else if (name == "TriggerRight")
                box.transform.position = p.gameObject.transform.position - new Vector3(.2f, 0);
            else if (name == "TriggerUp")
                box.transform.position = p.gameObject.transform.position - new Vector3(0, .2f);
            else if (name == "TriggerDown")
                box.transform.position = p.gameObject.transform.position + new Vector3(0, .2f);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && onlyOne)
        {
            canBeGrabbed = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            canBeGrabbed = false;
    }
}
