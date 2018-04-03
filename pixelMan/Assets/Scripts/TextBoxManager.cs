using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject dialogPanel;

    public Text textOutput;

    public TextAsset textFile;
    public string[] textLines;

    public int curLine;
    public int endLine;

    public PlayerControllerVer2 player;

    public TextAsset BlankTextFile;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerControllerVer2>();

        endLine = 0;
        curLine = 0;

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endLine == 0)
        {
            endLine = textLines.Length - 1;
        }

        dialogPanel.SetActive(false);
    }

    //turns on the textbox and sets its text object
    public void StartDialog(TextAsset newTextFile)
    {
        if(newTextFile != null)
        {
            //load new text file into text manager
            textLines = (newTextFile.text.Split('\n'));
            //reset line counter
            curLine = 0;
            endLine = textLines.Length - 1;
            //enable the dialog panel
            dialogPanel.SetActive(true);
            player.canMove = false;
        }
        else
        {
            Debug.LogError("Empty Text File!");
        }

    }
    public void MissingDialog()
    {
        StartDialog(BlankTextFile);
    }

    // Update is called once per frame
    void Update()
    {
        textOutput.text = textLines[curLine];

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            curLine++;
            if (curLine > endLine)
            {
                dialogPanel.SetActive(false);
                curLine = 0;
                player.canMove = true;
            }
        }

        
    }
}
