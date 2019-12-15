using UnityEngine;

public class GravityController : MonoBehaviour
{
    public Collider attractor;
    public float gravityScale;
    
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        rb.position = Vector3.MoveTowards(rb.position, attractor.ClosestPointOnBounds(rb.position), gravityScale * Time.deltaTime);
    }
}
