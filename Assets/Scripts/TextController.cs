using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{

    private Text text;
    public int playerNumber;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int myCode=(int) Keycodes.getPlayerCode(playerNumber);
        text.text = myCode.ToString();
    }
}
