using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float facingDir;
    [SerializeField] float moveSpeed;
    [SerializeField] float bubbleCooldown, bubbleTimer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool pressedBubble;

    [SerializeField] IBubbleSpawner[] bubbleSpawners;


    void Start()
    {
        facingDir = 1;
        RetrieveInput();
    }

    void Update()
    {
        RetrieveInput();

        bubbleCooldown -= Time.deltaTime;
    }

    void RetrieveInput()
    {
        moveInput = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );
        
        if(moveInput.x != 0){facingDir = moveInput.x;}

        // if(Input.GetKeyDown(KeyCode.Space)){Jump();}
        if(Input.GetKeyDown(KeyCode.F)){
            ShootBubble();
        };
    }

    public void ShootBubble()
    {
        if(bubbleTimer > 0) return;

        bubbleSpawners[Random.Range(0, bubbleSpawners.Length)].SpawnBubble(moveInput.x);
        
        bubbleTimer = bubbleCooldown;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            moveInput.x * moveSpeed,
            rb.linearVelocity.y
        );
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            GameManager.Instance.EndGame();
        }   
    }
}
