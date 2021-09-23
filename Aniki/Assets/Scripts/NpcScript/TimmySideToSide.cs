using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimmySideToSide : MonoBehaviour
{
    public float jumpFactor;
    public float speed;


    private bool isGrounded;

   public Rigidbody2D rb;

    public Transform Trigger1;

    public Transform Trigger2;


    public Vector2 mov;


    bool toTrigger2;


    public bool isWandering;

    public bool isFollowing = true;


    public Transform target;

    public float minDistance;

    public bool canJump = true;
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

    
        if (isFollowing)
        {
            timmyIsFollowing();
        }
        if (isWandering)
        {
            wandering();
        }




    }


    void wandering()
    {
        // caminar del punto 1 al punto 2 a velocidad constante

        if (toTrigger2)
        {
            mov = Trigger2.transform.position - transform.position;

            mov = mov.normalized;

            rb.velocity = mov * speed;
        }

        if (toTrigger2 == false)
        {
            mov = Trigger1.transform.position - transform.position;

            mov = mov.normalized;

            rb.velocity = mov * speed;
        }


    }

    void jump()
    {
        if (Input.GetKey("x") && isGrounded)
        {

            rb.velocity = Vector2.up * jumpFactor;

        }
    }



    private void OnTriggerEnter2D(Collider2D outsider)
    {
        if (outsider.gameObject.CompareTag("Trigger2"))
        {


            toTrigger2 = false;


        }
        if (outsider.gameObject.CompareTag("Trigger1"))
        {

            toTrigger2 = true;

        }

        if (outsider.gameObject.CompareTag("SideToSide"))
        {
            isFollowing = false;

            isWandering = true;

        }





    }




    void timmyIsFollowing()
    {

        if (isGrounded)
        {


            if (Vector2.Distance(this.transform.position, target.transform.position) > minDistance)
            {


                mov = target.transform.position - transform.position;

                mov = mov.normalized;

                rb.velocity = (mov * Vector2.right).normalized * speed;

            }
            else rb.velocity = Vector2.zero;

        }

        /*  if(Vector2.Distance(this.transform.position, target.transform.position) <= minDistance)
          {
              rb.velocity = Vector2.zero;
          }*/
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {

            isGrounded = true;

        }

    }
    private void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {

            isGrounded = false;

        }

    }


}
