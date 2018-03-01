using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingSlot : MonoBehaviour
{
    bool paintingPresent;

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Painting")
            paintingPresent = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Painting")
            paintingPresent = false;
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
