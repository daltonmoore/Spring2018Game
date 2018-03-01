using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingSlots : MonoBehaviour
{
    GameObject[] slots;
	// Use this for initialization
	void Start ()
    {
        slots = GameObject.FindGameObjectsWithTag("PaintingSlot");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
