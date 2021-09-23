using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyBear : MonoBehaviour
{



    private bool playerInRange;

    public AudioSource feedback;
    

 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (playerInRange && Input.GetKeyDown(KeyCode.Z))
        {



            StartCoroutine(pickedUp());

        }
    
    
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            playerInRange = true;

        }



    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            playerInRange = false;
        }

      

    }



    IEnumerator pickedUp()
    {
        feedback.Play();
        yield return new WaitForSeconds(0.6f);

        gameObject.SetActive(false);
    }

}
