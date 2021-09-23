using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float moveSpeed;
    float movementInput;
   public Rigidbody2D rb;

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
        movementInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(movementInput * moveSpeed, rb.velocity.y);
    }

}
