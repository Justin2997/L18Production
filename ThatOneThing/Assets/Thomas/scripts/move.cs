using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private bool ismoving;

    static public bool blockMovement = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!blockMovement)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.AddForce(Vector2.up * speed);
                ismoving = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddForce(-Vector2.right * speed);
                ismoving = true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(-Vector2.up * speed);
                ismoving = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddForce(Vector2.right * speed);
                ismoving = true;
            }
        }

        Animator animator = GetComponent<Animator>();

        ismoving = Mathf.Abs(rb.velocity.x) > 0.1 || Mathf.Abs(rb.velocity.x) > 0.1;
        animator.SetBool("IsMoving", ismoving);

        if (Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y))
        {
            animator.SetFloat("xVelocity", rb.velocity.x);
            animator.SetFloat("yVelocity", 0);
        }
        else
        {
            animator.SetFloat("yVelocity", rb.velocity.y);
            animator.SetFloat("xVelocity", 0);
        }

    }
}


