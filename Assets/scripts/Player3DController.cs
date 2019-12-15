using UnityEngine;

public class Player3DController : MonoBehaviour {
    public float moveSpeed = 2.5f;
    public float jumpForce = 250.0f;
    public bool facingRight = true;

    Rigidbody rb;
    
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
    void FixedUpdate ()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        
        rb.velocity = new Vector3(moveHorizontal * moveSpeed, moveVertical * moveSpeed, 0);

        if (moveHorizontal < 0 && facingRight || moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }
    }

    // void Update()
    // {
    //     if (Input.GetButtonDown("Jump"))
    //     {
    //         rb.AddForce(Vector3.up * jumpForce);
    //     }
    // }

    void Flip()
    {
        facingRight = !facingRight;

        var transform1 = transform;
        var scale = transform1.localScale;
        scale.x *= -1;
        transform1.localScale = scale;
    }
}