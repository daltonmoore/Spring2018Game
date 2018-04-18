using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneButton : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {

	}

    private void Update()
    {
        if(Time.timeSinceLevelLoad > 51)
        {
            SceneManager.LoadScene(2);
        }
    }
}
