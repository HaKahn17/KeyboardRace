﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{

    private Text text;
    public int playerNumber;
    private Dictionary<int, string> ascii;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        ascii = new Dictionary<int, string>();
        foreach(var key in Keycodes.getCodes())
        {
            ascii.Add((int)key, key.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        int myCode=(int) Keycodes.getPlayerCode(playerNumber);
        text.text = Mutilate(ascii[myCode]);
        
    }

    private string Mutilate(string input)
    {
        if (input.Equals("RightBracket"))
        {
            return "]";
        }
        if (input.Equals("LeftBracket"))
        {
            return "[";
        }
        if (input.Equals("Space"))
        {
            return "___";
        }
        if (input.Equals("Backslash"))
        {
            return "\\";
        }
        if (input.Equals("Minus"))
        {
            return "-";
        }
        if (input.Equals("Comma"))
        {
            return ",";
        }
        if (input.Equals("Quote"))
        {
            return "'";
        }
        if (input.Equals("Period"))
        {
            return ".";
        }
        if (input.Equals("Slash"))
        {
            return "/";
        }
        if (input.Equals("Semicolon"))
        {
            return ";";
        }
        if (input.Equals("Equals"))
        {
            return "=";
        }
        if(input.Equals("None"))
        {
            return "bad";
        }
        if (input.Contains("Alpha"))
        {
            return input.Substring(5);
        }
        if (input.Equals("At"))
        {
            return "";
        }
        else
            return input;

        
    }
}
