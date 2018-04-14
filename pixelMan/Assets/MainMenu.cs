using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//allows unity to change scene

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(1);//gets the scene dungeon 
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
