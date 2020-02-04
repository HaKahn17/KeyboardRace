using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour {

    public GameObject Player3;
    public GameObject Player4;

    private GameManager gm;
    public void Start()
    {
        Player3.SetActive(false);
        Player4.SetActive(false);

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
        if (val > 2) {
            Player3.SetActive(true);
        } else {
            Player3.SetActive(false);
        }
        if (val > 3) {
            Player4.SetActive(true);
        } else {
            Player4.SetActive(false);
        }
    }
}