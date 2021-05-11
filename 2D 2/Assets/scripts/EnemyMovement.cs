using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSspeed = 2f;
    bool isFacingRight;
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            rigidbody2D.velocity = new Vector2(moveSspeed, 0);

        }
        else
        {
            rigidbody2D.velocity = new Vector2(-moveSspeed, 0);

        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rigidbody2D.velocity.x)), transform.localScale.y);
    }




    public bool IsFacingRight()
    {

        return transform.localScale.x > 0;
    }
}
