using UnityEngine;
using Game.Player.Controller;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 2.9f;
    public float jumpForce = 850.0f;
    public bool facingRight = true;

    public GameObject cam;
    // public Transform groundCheck;
    // public float groundRadius = 0.1f;
    // public LayerMask whatIsGround;
    
    // bool grounded;
	
    Rigidbody2D rb;

    private Moving Moves;
    // Use this for initialization
    
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        Moves = new Moving();
        Moves.Setup(rb, moveSpeed);
    }
	
    // Update is called once per frame
    void FixedUpdate ()
    {
        // grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		
        var moveHorizontal = Input.GetAxis("Horizontal");
        
        Moves.Run(moveHorizontal);
        
        if (moveHorizontal < 0 && facingRight || moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }

        if (rb.position.y >= 30 || rb.position.y <= 530)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, rb.position.y, cam.transform.position.z);
        }
        
        if (Input.GetButtonDown("Jump")) //  && grounded
        {
            Moves.Jump(Vector2.up * jumpForce);
        }
        
    }

    void Update()
    {
        if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        var transform1 = transform;
        var scale = transform1.localScale;
        scale.x *= -1;
        transform1.localScale = scale;
    }
}
