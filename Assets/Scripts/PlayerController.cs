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
    public Sprite[] runSprites;
    public Sprite[] jumpSprites;

    private Rigidbody2D rb2d;
    private AudioSource audioSource;
    private SpriteRenderer sr;
    private Collider2D col;
    private KeyCode currentKey;
    private bool isDead;
    private float realSpeed;

    public int framesPerSecond;
    private int currentFrameIndex;
    private bool grounded;

    // Start is called before the first frame update
    void Start() 
    {
        realSpeed = moveSpeed;
        // Disable in case of too many players
        if (playerNum > GameManager.instance.playersRemaining) {
            gameObject.SetActive(false);
        } else {
            gameObject.SetActive(true);
            StartCoroutine("PlayAnimation");
        }

        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        RandomizeKey();
        isDead = false;
        currentFrameIndex = 0;
    }

    // Update is called once per frame
    void Update() 
    {
       
        if (isDead)
            return;
        grounded = IsGrounded();
        if (Input.GetKeyDown(currentKey) && grounded) 
        {
            audioSource.PlayOneShot(jumpNoise);
            rb2d.velocity += Vector2.up * jumpSpeed;
            RandomizeKey();
        }
        else if (grounded)
        {
            rb2d.velocity = new Vector2(realSpeed, rb2d.velocity.y);
        }
    }

    bool IsGrounded()
    {
        return col.IsTouchingLayers(playerMask | groundLayer) ;

        /*
        LayerMask combined = groundLayer | playerMask;
        Vector2 origin = transform.position - new Vector3(0, GetComponent<BoxCollider2D>().size.y/2);
        var hit = Physics2D.Raycast(origin, -Vector2.up, .1f, combined);
        Debug.DrawRay(origin, -Vector2.up, Color.green);
        return hit.collider != null;
        */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Despawn")&&!isDead)
        {
            FindObjectOfType<GameManager>().playersRemaining--;
            //TODO make a coroutine so noise is played
            StartCoroutine(die());
            
        }
        if(collision.collider.gameObject.CompareTag("Invisible Wall"))
        {
            realSpeed = 0;
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

  
    IEnumerator PlayAnimation() {
        while (true) {

            yield return new WaitForSeconds(1f / framesPerSecond);
            if (grounded) {
                if (currentFrameIndex >= runSprites.Length) {
                    currentFrameIndex = 0;
                }
                sr.sprite = runSprites[currentFrameIndex];
                currentFrameIndex++;
                
            } else {
                if (currentFrameIndex >= jumpSprites.Length) {
                    currentFrameIndex = 0;
                }
                sr.sprite = jumpSprites[currentFrameIndex];
                currentFrameIndex++;
                
            }
        }
    }
}
