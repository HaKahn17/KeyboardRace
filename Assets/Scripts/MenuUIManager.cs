using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour {

    private GameManager gm;
    public void Start()
    {
        gm = GameManager.instance;
    }
    public void loadLevel(string level) {
        SceneManager.LoadScene(level);
    }

    public void exitGame() {
        Application.Quit();
    }

    public void SetNumPlayers(float val)
    {
        gm.SetNumPlayers(val);
    }
}