using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    

    public float moveSpeed = 2;
    public float jumpForce = 2;
    Rigidbody2D  rb2D;
    private float HorizontalMovement;

    public int facing = 1;

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement = Input.GetAxis("Horizontal");
        float flipX = Input.GetAxisRaw("Horizontal");


        if (flipX != 0 && canMove == true)
        {
            FlipPlayer(flipX);
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpForce);
            rb2D.velocity += jumpVelocity;
        }



        

    }

    private void FixedUpdate() {
        Walk();

    }
    public void Walk()
    {
        Vector2 playerVelocity = new Vector2(HorizontalMovement * moveSpeed, rb2D.velocity.y);
        rb2D.velocity = playerVelocity;

    }




    public void FlipPlayer(float x)
    {
        transform.localScale = new Vector2(x, transform.localScale.y);
        facing = (int)x;
    }
    


}
