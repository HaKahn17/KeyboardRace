using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Powerup
{

    private PlayerController pc;
    private PlayerController[] players;
    private SpriteRenderer sr;

    private int playerNumber;

    public override void Effect(GameObject player)
    {
        pc = player.GetComponent<PlayerController>();
        playerNumber = pc.playerNum;
        players = FindObjectsOfType<PlayerController>();
        foreach (var p in players)
        {
            if (p.playerNum != playerNumber)
            {
                Debug.Log(p.playerNum);
                p.BlockKey();
            }

        }
        sr.enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
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
                Debug.Log(player.playerNum);
                player.RandomizeKey();
            }
            
        }
        Destroy(gameObject);
    }
}
