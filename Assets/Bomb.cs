using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Powerup
{

    private PlayerController pc = null;

    private SpriteRenderer sr;

    private int playerNumber;

    private float gravity;
    public GameObject splode;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    public override void Effect(GameObject player)
    {
        if (pc != null)
            return;
        pc = player.GetComponent<PlayerController>();
        playerNumber = pc.playerNum;
        gravity = pc.GetComponent<Rigidbody2D>().gravityScale;
        pc.GetComponent<Rigidbody2D>().gravityScale = 0;
           
        sr.enabled = false;
        StartCoroutine(Timer(duration));
    }

    public override IEnumerator Timer(float dur)
    {
        var obj=Instantiate(splode, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(dur);
        pc.GetComponent<Rigidbody2D>().gravityScale = gravity;
        Destroy(obj);
        Destroy(gameObject);
    }
}
