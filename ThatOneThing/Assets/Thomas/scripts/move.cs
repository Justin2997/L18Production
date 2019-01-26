using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private bool ismoving;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * speed);
            ismoving = true;
        }
        else
        {
            ismoving = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-Vector2.right * speed);
            ismoving = true;
        }
        else
        {
            ismoving = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-Vector2.up * speed);
            ismoving = true;
        }
        else
        {
            ismoving = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * speed);
            ismoving = true;
        }
        else
        {
            ismoving = false;
        }
    }
}


