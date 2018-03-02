using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int curLine;
    public int endLine;

    public PlayerController player;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();


        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endLine == 0)
        {
            endLine = textLines.Length - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        theText.text = textLines[curLine];

        if (Input.GetKeyDown(KeyCode.Return))
        {
            curLine++;
            if (curLine > endLine)
            {
                textBox.SetActive(false);
                curLine = 0;
            }
        }

        
    }
}
