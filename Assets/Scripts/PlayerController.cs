using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour {
    public float jumpSpeed;
    public float moveSpeed;
    public LayerMask groundLayer;
    public LayerMask playerMask;
    public int playerNum; 

    private Rigidbody2D rb2d;
    private KeyCode currentKey;

    // Start is called before the first frame update
    void Start() 
    {
        // Disable in case of too many players
        if (playerNum > GameManager.instance.playersRemaining)
            gameObject.SetActive(false);

        rb2d = GetComponent<Rigidbody2D>();
        RandomizeKey();
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown(currentKey) && IsGrounded()) 
        {
            rb2d.velocity += Vector2.up * jumpSpeed;
            RandomizeKey();
        }
        else if (IsGrounded())
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
    }

    bool IsGrounded()
    {
        LayerMask combined = groundLayer | playerMask;
        Vector2 origin = transform.position - new Vector3(0, .6f);
        var hit = Physics2D.Raycast(origin, -Vector2.up, .1f, combined);
        Debug.DrawRay(origin, -Vector2.up, Color.green);
        return hit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Despawn"))
        {
            FindObjectOfType<GameManager>().playersRemaining--;
            Destroy(gameObject);
        }
    }
    
    private void RandomizeKey() {

        Keycodes.getNewCode(playerNum);
        currentKey = Keycodes.getPlayerCode(playerNum);
        
    }
}
