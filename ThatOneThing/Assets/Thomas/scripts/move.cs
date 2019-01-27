using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private Rigidbody2D rb;
    public bool ismoving;

    private void Start()
    {
    }

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

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
