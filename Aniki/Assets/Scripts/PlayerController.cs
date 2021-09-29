using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public AudioSource steps;


    public float moveSpeed = 500f;

    public float jumpForce;

    public float fallingJumpForce;

    public Rigidbody2D rb;


    private bool isGrounded;

    private bool isWalled;

    public Transform groundCheck;

    public Transform wallCheck;

    public float checkRadius;

    public float wallCheckRadius;

    public LayerMask whatIsGround;

    public LayerMask whatIsWall;

    private int extraJumps;

    public int extraJumpValue;

   public PhysicsMaterial2D slickMat;

   public PhysicsMaterial2D rugosoMat;


    bool isWalking;

    bool isSteping = true;

    public bool controls;

    private bool isLookingRight = true;
 

    Vector2 movement;

    //pene

    private float movementInput;


    private bool isTouchingGround;

    // Start is called before the first frame update
    void Start()
    {

        extraJumps = extraJumpValue;
        rb.freezeRotation = true;


        controls = true;
    }

    // Update is called once per frame
    void Update()
    {



      
        if (isTouchingGround && (Input.GetKey("left") || Input.GetKey("right")) && !steps.isPlaying)
        {

            steps.volume = Random.Range(0.7f, 0.8f);
            steps.pitch = Random.Range(1.10f, 1.25f);
            steps.Play();
        }
      

        animationController();

        if (isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow)&& extraJumps > 0 && controls)
        {
            rb.velocity = Vector2.up * jumpForce;
           // rb.velocity = new Vector2(rb.velocity.x, 1) * jumpForce;

            extraJumps--;
        } else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true && controls){

            rb.velocity = Vector2.up * jumpForce;
           // rb.velocity = new Vector2(rb.velocity.x, 1) * jumpForce;

        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0 && !controls)
        {
          //  rb.velocity = Vector2.up * jumpForce;
             rb.velocity = new Vector2(1, 1) * fallingJumpForce;

            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true && !controls)
        {

           // rb.velocity = Vector2.up * jumpForce;

            rb.velocity = new Vector2(1, 1) * fallingJumpForce;

        }



    }

    private void FixedUpdate()
    {
        // Debug.Log(rb.velocity);

       
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        isWalled = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);



        
        movement.x = Input.GetAxis("Horizontal");


        movementInput = Input.GetAxisRaw("Horizontal");

        movement.y = Input.GetAxis("Vertical");


        //  rb.velocity = new Vector2( movement.x * moveSpeed, rb.velocity.y);


        if (controls /*&& Input.GetAxisRaw("Horizontal") != 0 */)
        {

        
       rb.velocity = new Vector2(movementInput * moveSpeed, rb.velocity.y);

        }

        if (isWalled)
        {
            rb.sharedMaterial = slickMat;

        


        }
        if(!isWalled)
        {
            rb.sharedMaterial = rugosoMat;
        }
    }


    public void animationController()
    {
        Debug.Log(isLookingRight);
        //if there is ANY movement imput, it leaves ANY idleling state. 
        if (Input.GetKey("up") || Input.GetKey("left") || Input.GetKey("right"))
        {

            rb.GetComponent<Animator>().SetBool("isIdlelingRight", false);
            rb.GetComponent<Animator>().SetBool("isIdlelingLeft", false);
        }

        //FLIP CONTROLLER
        //pl
        if (isTouchingGround == false)
        {

            if (rb.velocity.x < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (rb.velocity.x > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (rb.velocity.x == 0)
            {


                /*   if (!isLookingRight)
                   {
                       gameObject.GetComponent<SpriteRenderer>().flipX = true;
                   } */

                if (isLookingRight)
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }

            }


            //  isLookingRight = false;
            rb.GetComponent<Animator>().SetBool("isJumping", true);
        }

        else if (Input.GetKey("right"))
        {
            //note

            rb.GetComponent<Animator>().SetBool("isWalkingRight", true);



            isLookingRight = true;
        }
        else if (Input.GetKey("left"))
        {
            rb.GetComponent<Animator>().SetBool("isWalkingLeft", true);

            isLookingRight = false;
        }

        if (isTouchingGround)
        {

            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            rb.GetComponent<Animator>().SetBool("isJumping", false);
            // rb.GetComponent<Animator>().SetBool("idleUp", true);



        }
        if (isTouchingGround && !Input.GetKey("left") && !Input.GetKey("right") && !Input.GetKey("up"))
        {
            //   Debug.Log("Está tocando el suelo y no hay ninguna tecla pulsada");

            if (isLookingRight)
            {

                rb.GetComponent<Animator>().SetBool("isIdlelingRight", true);

            }
            else if (isLookingRight == false)
            {

                //  Debug.Log("Y por tanto el idle left is TRUE");

                rb.GetComponent<Animator>().SetBool("isIdlelingLeft", true);
            }

        }




        /* if (Input.GetKeyUp("up"))
         {
             rb.GetComponent<Animator>().SetBool("up", false);
             rb.GetComponent<Animator>().SetBool("idleUp", true);
         }*/


        //when you release the button the animation has to stop 

        if (Input.GetKeyUp("right"))
        {
            rb.GetComponent<Animator>().SetBool("isWalkingRight", false);


            isLookingRight = true;
        }
        if (Input.GetKeyUp("left"))
        {
            rb.GetComponent<Animator>().SetBool("isWalkingLeft", false);


            isLookingRight = false;
        }



    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")){

            isTouchingGround = true;

           // Debug.Log("Entrada:" + isTouchingGround);

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {

            isTouchingGround = false;

          //  Debug.Log("Salida:" + isTouchingGround);
        }
    }





}
