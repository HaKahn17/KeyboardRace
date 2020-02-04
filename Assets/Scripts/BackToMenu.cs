using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    void Start() {
        StartCoroutine("Reload");
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) {
            SceneManager.LoadScene("Title");
        }
    }

    public IEnumerator Reload() {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Title");  
    }
}
