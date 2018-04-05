using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingSlot : MonoBehaviour
{
    bool paintingPresent;
    bool codeSatisfied;
    public TextAsset PaintingText;
    public CanvasController canvas;

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Painting")
        {
            paintingPresent = true;
            if (name == "PaintingCodeSlot1" && collision.name == "Painting01")
            {
                codeSatisfied = true;
                canvas.Code1CorrectPopUp.SetActive(true);
                Time.timeScale = 0;
            }
            if (name == "PaintingCodeSlot2" && collision.name == "Painting02")
            {
                codeSatisfied = true;
                canvas.Code2CorrectPopUp.SetActive(true);
                Time.timeScale = 0;
            }
            if (name == "PaintingCodeSlot3" && collision.name == "Painting03")
            {
                codeSatisfied = true;
                canvas.Code3CorrectPopUp.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public bool getCodeSatisfied()
    {
        return codeSatisfied;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Painting")
        {
            paintingPresent = false;
            if (name == "PaintingCodeSlot1" && collision.name == "Painting01")
            {
                codeSatisfied = false;
            }
            if (name == "PaintingCodeSlot2" && collision.name == "Painting02")
            {
                codeSatisfied = false;
            }
            if (name == "PaintingCodeSlot3" && collision.name == "Painting03")
            {
                codeSatisfied = false;
            }
        }
    }

    public bool hasPainting()
    {
        return paintingPresent;
    }

    public void setPaintingPresent(bool paintingPresent)
    {
        this.paintingPresent = paintingPresent;
    }
}