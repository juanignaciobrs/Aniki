using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResbalarScript : MonoBehaviour
{

    public PhysicsMaterial2D slickMat;

    public PhysicsMaterial2D rugosoMat;

    public PlayerController player;

    public Rigidbody2D rb;

  

    
    // Start is called before the first frame update
    void Start()
    {
        GameObject g = GameObject.FindGameObjectWithTag ("Player");

        player = g.GetComponent<PlayerController>();

      

    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {


        player.controls = false;

        rb.sharedMaterial = slickMat;
        Debug.Log(player.controls);



     

        //  rb.velocity = Vector2.right * downSpeed * Time.deltaTime;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {


        player.controls = true;

        rb.sharedMaterial = slickMat;
        Debug.Log(player.controls);





        //  rb.velocity = Vector2.right * downSpeed * Time.deltaTime;
    }


}
