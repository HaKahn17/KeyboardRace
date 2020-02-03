using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour {
    public float jumpSpeed;
    public LayerMask groundLayer;
    public int playerNum; 

    private Rigidbody2D rb2d;
    private KeyCode currentKey;

    // Start is called before the first frame update
    void Start() 
    {
        rb2d = GetComponent<Rigidbody2D>();
        currentKey = Keycodes.getPlayerCode(playerNum);
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown(currentKey) && IsGrounded()) 
        {
            rb2d.velocity += Vector2.up * jumpSpeed;
            RandomizeKey();
        }
    }

    bool IsGrounded()
    {
        var hit = Physics2D.Raycast(transform.position, -Vector2.up, 1f, groundLayer);
        return hit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
    
    private void RandomizeKey() {

        Keycodes.getNewCode(playerNum);
        currentKey = Keycodes.getPlayerCode(playerNum);
        
    }
}
