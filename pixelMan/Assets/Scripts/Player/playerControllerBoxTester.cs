using UnityEngine;
using System.Collections;

public class playerControllerBoxTester : MonoBehaviour
{
    public bool grabbed;
    GameObject box;
    Vector3 left = new Vector3(.3f, 0), right = new Vector3(-.3f,0), up = new Vector3(0, .3f), down = new Vector3(0, -.3f);
    Rigidbody2D boxRigid, playerRigid;
    public float speed,x, y;

	// Use this for initialization
	void Start ()
    {
        playerRigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime;
        y = Input.GetAxis("Vertical") * Time.fixedDeltaTime;
        //transform.position += new Vector3(x, y);
        playerRigid.AddForce(new Vector2(x*speed,y*speed));

        rotateGrabber(x,y);
        grab();
	}

    public void setGrab(GameObject o)
    {
        box = o;
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

    void grab()
    {
        if (Input.GetKeyDown(KeyCode.E) && box != null)
        {
            grabbed = !grabbed;
        }
        if (grabbed && box != null)
        {
            boxRigid = box.GetComponent<Rigidbody2D>();
            if (Mathf.Abs(box.transform.position.y - transform.position.y) < .1f)//not above or below box
            {
                if (box.transform.position.x - transform.position.x > 0)//box is on your right and you're grabbing it
                {
                    if (Vector3.Distance(box.transform.position, transform.position) > .3f)
                        boxRigid.AddForce(new Vector2(speed*x,speed*y));
                }
                else if (box.transform.position.x - transform.position.x < 0)
                    box.transform.position = transform.position + right;
            }
            else
            {
                if (box.transform.position.y - transform.position.y > 0)
                    box.transform.position = transform.position + up;
                else if (box.transform.position.y - transform.position.y < 0)
                    box.transform.position = transform.position + down;
            }
        }
        if (box == null)
            grabbed = false;

    }
}
