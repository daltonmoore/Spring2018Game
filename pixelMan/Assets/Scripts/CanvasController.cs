using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController singleton;

    public GameObject popUpCantPlace;
    public Button popUpCantPlaceButton;

    private CanvasController()
    {

    }

	void Start ()
    {
        singleton = this;
        popUpCantPlace.SetActive(false);        
        popUpCantPlaceButton.onClick.AddListener(closeCantPlacePopUp);

	}
	
	void Update ()
    {

	}

    void closeCantPlacePopUp()
    {
        popUpCantPlace.SetActive(false);
        Time.timeScale = 1;
    }
}
