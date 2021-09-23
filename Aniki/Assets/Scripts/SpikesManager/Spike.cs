using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    bool isUp;

    public Rigidbody2D spike;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per framezxcz
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.CompareTag("Player") && isUp == false)
        {
            Debug.Log("Llegó el player TRIGGER");

            spike.velocity = Vector2.up * 100;

            isUp = true;

        }


        if (other.gameObject.CompareTag("SpikeStopper"))
        {

            spike.velocity = Vector2.zero;
            spike.velocity = Vector2.down * 10;
        }



        if (other.gameObject.CompareTag("SpikeBase"))
        {

            spike.velocity = Vector2.zero;
            spike.velocity = Vector2.down * 10;
        }
    }

   

}
