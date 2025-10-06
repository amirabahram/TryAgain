using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveForce = 20f, jumpForce = 50f, maxVelocity = 5f;
    private Rigidbody2D myBody;
    private bool grounded;
    private float scaleFactor = 1;
    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float forceX = 0;
        float forceY = 0;
        float vel = Mathf.Abs(myBody.linearVelocity.x);
        float hor = Input.GetAxisRaw("Horizontal");

        if (hor>0)
        {
            if (vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = moveForce;
                }
                else
                {
                    forceX = moveForce * 1.1f;
                }
            }
            scaleFactor = 1;
        }else if (hor<0)
        {
            if (vel < maxVelocity)
            {
                if (grounded)
                {
                    forceX = -moveForce;
                }
                else
                {
                    forceX = -moveForce * 1.1f;
                }
            }
            scaleFactor = -1;
        }
        else
        {
            
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                forceY = jumpForce;
            }
        }
        Vector3 scale = transform.localScale;
        scale.x = scaleFactor;
        transform.localScale = scale;
        myBody.AddForce(new Vector2(forceX, forceY));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
