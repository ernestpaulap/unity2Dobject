using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public float moveSpeed = 2;
    public float jumpForce = 2;
    Rigidbody2D rb2D;
    private float HorizontalMovement;
    public float climbSpeed = 2;
    public int facing = 1;

    public bool canMove = true;
    public CircleCollider2D myFeet;

    private float gravityScaler;
    private bool isAlive = true;





    // Start is called before the first frame update

    void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();
        gravityScaler = rb2D.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive==false)
        {

            return;


        }
        HorizontalMovement = Input.GetAxis("Horizontal");
        float flipX = Input.GetAxisRaw("Horizontal");


        if (flipX != 0 && canMove == true)
        {
            FlipPlayer(flipX);
        }

        if (Input.GetButtonDown("Jump") && myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpForce);
            rb2D.velocity += jumpVelocity;
        }

        climbLadder();



    }

    private void FixedUpdate()
    { 
        if(!isAlive)
        
        {
        return;
        
        }
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

public void climbLadder()
{
    if (!myFeet.IsTouchingLayers(LayerMask.GetMask("climbing")))
    {

        rb2D.gravityScale = gravityScaler;
        return;

    }

    float verticalMovement = Input.GetAxis("Vertical");
    Vector2 climbVelocity = new Vector2(0, verticalMovement * climbSpeed);
    rb2D.gravityScale = 0;
    rb2D.velocity = climbVelocity;
}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<EnemyMovement>()) 
        { 
        if(isAlive)
            {
                Die();
            }
        
        
        }

    }
    public void Die()
    {

        isAlive = false;
        rb2D.velocity = Vector3.zero;
    
    }

}
