using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorTriggerScript : MonoBehaviour
{
    public TextBoxManager tbm;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(tbm.completedDialog)
            SceneManager.LoadScene(2);
    }
}