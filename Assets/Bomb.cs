using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Powerup
{

    public GameObject splode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Effect(GameObject player)
    {
        StartCoroutine(Timer(duration));
    }

    public override IEnumerator Timer(float dur)
    {
        Instantiate(splode, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(dur);
        Destroy(gameObject);
    }
}
