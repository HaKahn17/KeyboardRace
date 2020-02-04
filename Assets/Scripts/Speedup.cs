using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedup : Powerup
{

    private PlayerController pc;
    private SpriteRenderer sr;

    public override void Effect(GameObject player)
    {
        pc = player.GetComponent<PlayerController>();
        pc.moveSpeed += 2;
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
        yield return new WaitForSeconds(duration);
        pc.moveSpeed -= 2;
        Destroy(gameObject);
    }
}
