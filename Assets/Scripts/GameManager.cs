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
        if (playersRemaining == 1 && !gameOver)
        {
            // If one player is remaining reload the scene
            //TODO: Change to main menu later
            gameOver = true;
            StartCoroutine(reload());
            
 
        }
    }

    public void SetNumPlayers(float val)
    {
        playersRemaining = (int)val;
    }

    public IEnumerator reload()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Title");
    }
}
