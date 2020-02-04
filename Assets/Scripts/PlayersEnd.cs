using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersEnd : MonoBehaviour
{

    public Sprite[] wonSprites;
    public Sprite[] lostSprites;

    private bool won;

    private int framesPerSprite;

    private SpriteRenderer sp;
    private int n;
    private int k;
    // Start is called before the first frame update
    void Start()
    {
        if(won)
        {
            transform.position = new Vector2(7,1.2F);
        }
        else
        {
            transform.position = new Vector2(-4, 0);
        }
        sp = GetComponent<SpriteRenderer>();
        n = 0;
        k = 0;
    }

    // Update is called once per frame
    void Update()
    {
        n++;
        if (n == framesPerSprite)
        {
            n = 0;
            k++;
        }
        if (k > 2)
            k = 0;
        if (won)
            sp.sprite = wonSprites[k];
        else
            sp.sprite = lostSprites[k];
    }
}
