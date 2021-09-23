using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimmyAnimationController : MonoBehaviour
{


    public Rigidbody2D rb;
    // sdfStart is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void  Update()
    {
     if(rb.velocity.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            rb.GetComponent<Animator>().SetBool("isWalkingRight", true);

        }
       else if (rb.velocity.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            rb.GetComponent<Animator>().SetBool("isWalkingRight", true);

        }

     if (rb.velocity.x == 0)
        {
            rb.GetComponent<Animator>().SetBool("isWalkingRight", false);
        }
     //comment

     if(rb.velocity.y > 0 && rb.velocity.x == 0 || rb.velocity.y < 0 && rb.velocity.x == 0)
        {
            
            rb.GetComponent<Animator>().SetBool("isJumping", true);
        }

     if( (rb.velocity.y == 0 && rb.velocity.x == 0 ) || ( rb.velocity.y > 0 || rb.velocity.y < 0 && rb.velocity.x < 0 || rb.velocity.x > 0 )   )
        {
            rb.GetComponent<Animator>().SetBool("isJumping", false);
        }

     


    }
}
