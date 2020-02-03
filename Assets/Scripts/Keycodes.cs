using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Keycodes 
{
    private static KeyCode[] playerKeycodes=new KeyCode[4];
    private static List<KeyCode> allCodes;

    public static void addCodes()
    {
        int[] keysToAdd = { 32, 39, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 59, 61, 91, 92, 93, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 273, 274, 275, 276};        
        allCodes = new List<KeyCode>();
        foreach(var key in keysToAdd)
        {
            allCodes.Add((KeyCode)key);
        }
    }
    
    
    
}
