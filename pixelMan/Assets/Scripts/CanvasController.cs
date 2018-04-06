using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CanvasController : MonoBehaviour
{
    public GameObject CanNotPlacePaintingPopUp;
    Button canNotPlacePaintingAck;

    public GameObject Code1CorrectPopUp;
    Button code1CorrectAck;

    public GameObject Code2CorrectPopUp;
    Button code2CorrectAck;

    public GameObject Code3CorrectPopUp;
    Button code3CorrectAck;

    public GameObject inspectPopUp;

    void Start ()
    {
        setUpButton(CanNotPlacePaintingPopUp, canNotPlacePaintingAck, CanNotPlacePaintingOk);
        setUpButton(Code1CorrectPopUp, code1CorrectAck, Code1CorrectOk);
        setUpButton(Code2CorrectPopUp, code2CorrectAck, Code2CorrectOk);
        setUpButton(Code3CorrectPopUp, code3CorrectAck, Code3CorrectOk);
    }

    void setUpButton(GameObject parent, Button b, UnityAction listener)
    {
        foreach (Transform child in parent.transform)
        {
            if (child.name == "Button")
                b = child.GetComponent<Button>();
        }
        b.onClick.AddListener(listener);
    }

    void CanNotPlacePaintingOk()
    {
        CanNotPlacePaintingPopUp.SetActive(false);
        Time.timeScale = 1;
    }

    void Code1CorrectOk()
    {
        Code1CorrectPopUp.SetActive(false);
        Time.timeScale = 1;
    }

    void Code2CorrectOk()
    {
        Code2CorrectPopUp.SetActive(false);
        Time.timeScale = 1;
    }

    void Code3CorrectOk()
    {
        Code3CorrectPopUp.SetActive(false);
        Time.timeScale = 1;
    }
}
