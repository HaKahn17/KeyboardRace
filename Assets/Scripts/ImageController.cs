using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour
{
    private GameManager gm;
    public int playerNumber;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        gameObject.SetActive(true);
        int[] onePlayer= { 0 };
        int[] twoPlayer = { -300, 300 };
        int[] threePlayer = { -400, 0, 400 };
        int[][] positions = {onePlayer, twoPlayer, threePlayer};
        if(gm.playersRemaining<playerNumber)
        {
            gameObject.SetActive(false);
        }
        else if(gm.playersRemaining<4)
        {
            transform.localPosition = new Vector2(positions[gm.playersRemaining-1][playerNumber-1], 200);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
