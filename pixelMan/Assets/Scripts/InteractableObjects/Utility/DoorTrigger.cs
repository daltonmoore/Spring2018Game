using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public string scene;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                try
                {
                    SceneManager.LoadScene(scene);
                }
                catch (Exception e)
                {
                    print(e.StackTrace);
                }
            }
        }
    }
}
