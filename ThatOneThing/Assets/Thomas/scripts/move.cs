using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private Rigidbody2D rb;
    public bool ismoving;

    static public bool blockMovement = false;

    private void Start()
    {
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
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

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        if (transform.position == transform.position + movement * Time.deltaTime * speed)
        {

            ismoving = false;
         
        }
        else
        {
            transform.position = transform.position + movement * Time.deltaTime * speed;

            ismoving = true;
          
        }

    }
}
