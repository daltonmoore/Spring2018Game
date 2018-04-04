using System.Collections;
using UnityEngine;

class PaintingCodeManager : MonoBehaviour
{
    public PaintingSlot[] paintingCodeSlots;
    public Animator animBookcase;
    
    void Start()
    {

    }

    

    void Update()
    {
        int count = 0;
        foreach (var item in paintingCodeSlots)
        {
            if (item.getCodeSatisfied())
                count++;
        }
        if (count == 3)
            animBookcase.SetBool("CodeGot", true);
    }
}


