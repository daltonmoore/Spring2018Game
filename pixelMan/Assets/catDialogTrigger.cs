using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catDialogTrigger : MonoBehaviour
{
    public GameObject popUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        popUp.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        popUp.SetActive(false);
    }
}
