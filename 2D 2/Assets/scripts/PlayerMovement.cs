using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    

         public float moveSpeed = 2;
    Rigidbody2D  rb2D;
    private float HorizontalMovement;



    // Start is called before the first frame update
    void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate(){
            Vector2 PlayerVelocity = new Vector2(HorizontalMovement * moveSpeed, rb2D.velocity.y);
            rb2D.velocity = PlayerVelocity;







}
}
