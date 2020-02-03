using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int PlayersRemaining {get; set; }

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
        
        Keycodes.addCodes();
        PlayersRemaining = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayersRemaining == 1)
        {
            // If one player is remaining reload the scene
            //TODO: Change to main menu later
            PlayersRemaining = 2;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
