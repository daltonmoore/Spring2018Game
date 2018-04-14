using System.Collections;
using UnityEngine;

class PaintingCodeManager : MonoBehaviour
{
    public Animator anim;
    public PaintingSlot[] paintingCodeSlots;
    public GameObject endGameTrigger;
    
    void Start()
    {
        anim.gameObject.SetActive(false);
        endGameTrigger = GameObject.Find("endGameCollider");
        endGameTrigger.SetActive(false);
    }
    int count = 0;
    bool done = false;
    void Update()
    {
        if (!done)
        {
            foreach (var item in paintingCodeSlots)
            {
                if (item.getCodeSatisfied())
                    count++;
            }
            if (count == 3)
            {
                GameObject.Find("Painting01").SetActive(false);
                GameObject.Find("Painting02").SetActive(false);
                GameObject.Find("Painting03").SetActive(false);
                anim.gameObject.SetActive(true);
                anim.Play("bookCaseOpening");
                endGameTrigger.SetActive(true);
                done = true;
            }
            else
            {
                count = 0;
            }
        }
    }
}


