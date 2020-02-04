using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Powerup
{

    private PlayerController pc;
    private SpriteRenderer sr;

    private int playerNumber;

    public override void Effect(GameObject player)
    {
        pc = player.GetComponent<PlayerController>();
        playerNumber = pc.playerNum;
        for (int i = 1; i <= 4; i++)
        {
            if (i != playerNumber)
            {
                Keycodes.BlockCode(i);
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
        PlayerController[] players = GetComponents<PlayerController>();
        foreach (var player in players)
        {
            Debug.Log(player.playerNum);
            player.RandomizeKey();
        }
        Destroy(gameObject);
    }
}
