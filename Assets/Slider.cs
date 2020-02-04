using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{


    private GameManager gm;
    private Slider sl;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        sl = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        sl.gm = gm;
    }
}
