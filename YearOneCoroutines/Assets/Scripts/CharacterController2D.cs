using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public Rigidbody2D rb;

    float horizontalInput;
    float verticalInput;

    [SerializeField] [Range(0, 200)] float force = 5f;
    [SerializeField] [Range(10, 200)] float maxSpeed = 20f;
    [SerializeField] [Range(1, 500)] float jumpForce = 5;
    [SerializeField] [Range(1, 200)] float groundCheckDistance = 3f;

    [SerializeField] bool isGrounded;
    private bool IsGrounded
    {
        get { return isGrounded; }
        set 
        {
            if (value != isGrounded)
            {
                if (value == true)
                {
                    transform.SetParent(hit.transform, true);

                }
                else
                {
                    transform.SetParent(null, true);

                }
                isGrounded = value;
            }
        }
    }


    [SerializeField] LayerMask groundLayer;

    RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        GroundCheck();

        if(Input.GetButtonDown("Jump") && IsGrounded)
        {
            Jump();
        }
    }

    // called in fixed intervals
    void FixedUpdate()
    {
        
        rb.AddForce(Vector2.right * horizontalInput * force);
        //for clamping the speed to the right
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        //for clamping the speed to the left
        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);

        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
    }

    private void GroundCheck()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer.value);

        if (hit.collider != null)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (transform.position + Vector3.down * groundCheckDistance));
    }
}
