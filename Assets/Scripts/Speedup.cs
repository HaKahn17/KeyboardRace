using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedup : Powerup
{
    public int speedIncrease;

    private PlayerController pc;
    private SpriteRenderer sr;

    public override void Effect(GameObject player)
    {
        pc = player.GetComponent<PlayerController>();
        pc.moveSpeed += speedIncrease;
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
        pc.moveSpeed -= speedIncrease;
        Destroy(gameObject);
    }
}
