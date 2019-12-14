using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 2.5f;
    public float jumpForce = 250.0f;
    public bool facingRight = true;

    // public Transform groundCheck;
    // public float groundRadius = 0.1f;
    // public LayerMask whatIsGround;
    
    // bool grounded;
	
    Rigidbody2D rb;
    
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
    // Update is called once per frame
    void FixedUpdate ()
    {
        // grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		
        var moveHorizontal = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);

        if (moveHorizontal < 0 && facingRight || moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) //  && grounded
        {
            rb.AddForce(Vector2.up * jumpForce);
        }

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
