using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int numPlayers;
    // Start is called before the first frame update
    void Start()
    {
        Keycodes.addCodes();
    }

    // Update is called once per frame
    void Update()
    {
        if (numPlayers == 0) {
            //TODO: go to title screen
        }
    }
}
