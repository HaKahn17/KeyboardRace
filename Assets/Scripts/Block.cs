using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Powerup
{

    private PlayerController pc = null;
    private PlayerController[] players;
    private SpriteRenderer sr;

    private int playerNumber;

    public override void Effect(GameObject player)
    {
        
        if (pc != null)
            return;
        pc = player.GetComponent<PlayerController>();
        playerNumber = pc.playerNum;
        
        players = FindObjectsOfType<PlayerController>();
        foreach (var p in players)
        {
            if (p.playerNum != playerNumber)
            {
                p.BlockKey();
            }

        }
        sr.enabled = false;
        StartCoroutine(Timer(duration));
    }


    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    IEnumerator Timer(float dur)
    {
        yield return new WaitForSeconds(dur);
        foreach (var player in players)
        {
            if (player.playerNum != playerNumber)
            {
                player.RandomizeKey();
            }
            
        }
        Destroy(gameObject);
    }
}
