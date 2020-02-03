using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour {
    public float jumpSpeed;
    public float moveSpeed;
    public LayerMask groundLayer;
    public LayerMask playerMask;
    public int playerNum;
    public AudioClip deathNoise;
    public AudioClip jumpNoise;
    public Sprite[] sprites;

    private Rigidbody2D rb2d;
    private AudioSource audioSource;
    private SpriteRenderer sr;
    private KeyCode currentKey;
    private bool isDead;

    // Start is called before the first frame update
    void Start() 
    {
        // Disable in case of too many players
        if (playerNum > GameManager.instance.playersRemaining)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);

        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        RandomizeKey();
        isDead = false;
    }

    // Update is called once per frame
    void Update() 
    {
        if (isDead)
            return;
        if (Input.GetKeyDown(currentKey) && IsGrounded()) 
        {
            audioSource.PlayOneShot(jumpNoise);
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
        Vector2 origin = transform.position - new Vector3(0, GetComponent<BoxCollider2D>().size.y/2);
        var hit = Physics2D.Raycast(origin, -Vector2.up, .1f, combined);
        Debug.DrawRay(origin, -Vector2.up, Color.green);
        return hit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Despawn")&&!isDead)
        {
            FindObjectOfType<GameManager>().playersRemaining--;
            //TODO make a coroutine so noise is played
            StartCoroutine(die());
            
        }
    }
    
    private void RandomizeKey() {

        Keycodes.getNewCode(playerNum);
        currentKey = Keycodes.getPlayerCode(playerNum);
        
    }

    public IEnumerator die()
    {
        isDead = true;
        audioSource.PlayOneShot(deathNoise);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
