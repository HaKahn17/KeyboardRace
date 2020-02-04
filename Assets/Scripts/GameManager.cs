using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int playersRemaining;
    public int winNum; 

    private bool gameOver;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        gameOver = false;
        winNum = 0;

        Keycodes.addCodes();
    }

    // Update is called once per frame
    void Update()
    {
        if (playersRemaining <= 1 && !gameOver)
        {
            playersRemaining = 2;
            // If one player is remaining reload the scene
            GameObject winner = GameObject.FindWithTag("Player");
            if (winner != null) {
                winNum = winner.GetComponent<PlayerController>().playerNum;
            } else {
                winNum = 0;
            }
            gameOver = true;

            StartCoroutine(Reload());
        }
    }

    public void SetNumPlayers(float val)
    {
        playersRemaining = (int)val;
    }

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(1);
        gameOver = false;
        if (winNum == 0) {
            SceneManager.LoadScene("Title");
        } else {
           //TODO load victory scene
            SceneManager.LoadScene("Title");
        }
    }
}
