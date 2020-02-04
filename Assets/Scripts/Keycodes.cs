using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Keycodes 
{
    private static KeyCode[] playerKeycodes;
    private static List<KeyCode> allCodes;

    public static void addCodes()
    {
        int[] keysToAdd = {32, 39, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 59, 61, 91, 92, 93, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 64};        
        allCodes = new List<KeyCode>();
        foreach(var key in keysToAdd)
        {
            allCodes.Add((KeyCode)key);
        }
        allCodes.Add(KeyCode.None);
        KeyCode[] start = {KeyCode.None, KeyCode.None, KeyCode.None, KeyCode.None};
        playerKeycodes = start;
    }

    public static KeyCode getPlayerCode(int playerNumber)
    {
        return playerKeycodes[playerNumber - 1];
    }

    public static void getNewCode(int playerNumber)
    {
        do
        {
            playerKeycodes[playerNumber - 1] = allCodes[Random.Range(0, allCodes.Count-2)];
        } while (playerKeycodes[playerNumber - 1] == playerKeycodes[playerNumber % 4] || playerKeycodes[playerNumber - 1] == playerKeycodes[(playerNumber + 1) % 4] || playerKeycodes[playerNumber - 1] == playerKeycodes[(playerNumber+2) % 4]);


    }

    public static List<KeyCode> getCodes()
    {
        return allCodes;
    }

    public static void BlockCode(int playerNumber)
    {
        playerKeycodes[playerNumber - 1] = KeyCode.At;
    }
}
