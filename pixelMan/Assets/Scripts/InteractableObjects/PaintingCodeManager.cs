using System.Collections;
using UnityEngine;

class PaintingCodeManager : MonoBehaviour
{
    public PaintingSlot[] paintingCodeSlots;
    
    void Start()
    {

    }
    int count = 0;
    void Update()
    {
        foreach (var item in paintingCodeSlots)
        {
            if (item.getCodeSatisfied())
                count++;
        }
        if (count == 3)
        {
            Application.Quit();
        }
        else
        {
            count = 0;
        }
    }
}


