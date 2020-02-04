using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
    public float duration;
    public float moveSpeed;

    public abstract void Effect(GameObject player);

    private void Update()
    {
        Vector3 movement = new Vector3(-moveSpeed, 0);
        transform.position += movement * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<CircleCollider2D>().enabled = false;
            Effect(collision.gameObject);
        }
    }

    public abstract IEnumerator Timer(float duration);

}
