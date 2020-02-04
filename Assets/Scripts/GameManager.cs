using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int playersRemaining;

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
        Keycodes.addCodes();
    }

    // Update is called once per frame
    void Update()
    {
        if (playersRemaining <= 1 && !gameOver)
        {
            playersRemaining = 2;
            // If one player is remaining reload the scene
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
        SceneManager.LoadScene("Title");
    }
}
