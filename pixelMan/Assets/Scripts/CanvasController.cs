using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Slider healthBar;

	void Start ()
    {
        healthBar.maxValue = PlayerController.singleton.health;
        healthBar.value = healthBar.maxValue;
	}
	
	void Update ()
    {
        if (healthBar.value != PlayerController.singleton.health)
            healthBar.value = PlayerController.singleton.health;
	}
}
