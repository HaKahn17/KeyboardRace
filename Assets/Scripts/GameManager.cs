using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int playersRemaining;

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

        playersRemaining = 3;
        Keycodes.addCodes();
    }

    // Update is called once per frame
    void Update()
    {
        if (playersRemaining == 1)
        {
            // If one player is remaining reload the scene
            //TODO: Change to main menu later
            SceneManager.LoadScene("Title");
            playersRemaining = 3;
        }
    }

    public void SetNumPlayers(float val)
    {
        playersRemaining = (int)val;
    }
}
