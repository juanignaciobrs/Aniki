using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimmyComeHereIntro : MonoBehaviour
{


    public Rigidbody2D rb;

    public float speed;

    public float jumpForce;

    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if (canMove)
        {

        
        rb.velocity = Vector2.right * speed;
        }

    }


    /*  private void OnTriggerEnter2D(Collider2D collision)
      {
          if (collision.gameObject.CompareTag("jump1"))
          {
              Debug.Log("JUMP");
            //  rb.velocity = new Vector2(rb.velocity.x, 1) * jumpForce;


              //EE
          }

          if (collision.gameObject.CompareTag("finishLine"))
          {
              canMove = false;

              rb.velocity = Vector2.zero;
          }
      }
    */

   


    private void OnTriggerEnter2D(Collider2D outsider)
    {
        if (outsider.gameObject.CompareTag("jump1"))
        {

            rb.AddForce(Vector2.up * jumpForce);

            Debug.Log("SALTA");
        }
        
    }

}