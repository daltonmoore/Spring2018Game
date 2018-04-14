using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    bool endGame = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            endGame = true;
    }

    public bool getEndGame()
    {
        return endGame;
    }
}
