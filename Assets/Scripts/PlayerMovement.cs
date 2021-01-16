using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float horizontal;
    float vertical;

    public float speed = 20.0f;
    public float diagonalMultiplier = 1.0f;
    public bool hasCloak = false;

    bool movingVert = false;
    bool movingHori = false;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        if (vertical > 0 || vertical < 0)
        {
            animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
            animator.SetFloat("Horizontal", 0);
        }
        else if (horizontal > 0 || horizontal < 0)
        {
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        }

        if (horizontal != 0 && vertical != 0)
        {
            diagonalMultiplier = 0.7f;
        }
        else 
        {
            diagonalMultiplier = 1.0f;
        }

        animator.SetBool("hasCloak", hasCloak);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed * diagonalMultiplier, vertical * speed * diagonalMultiplier );
    }


}
