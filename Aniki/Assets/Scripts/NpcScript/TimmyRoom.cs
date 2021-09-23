using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimmyRoom : MonoBehaviour
{


    public GameObject player;

    public GameObject timmy;


    public GameObject texto;

    private bool playerInRange;

    private bool textRead;

    public float f;

    public AudioSource audio;

    private bool waiting = true;

    // Start is called before the first frame update
    void Start()
    {
        //sd
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange && !textRead){


            texto.SetActive(true);
            //texto
            textRead = true;
        }
    
        if(Input.GetKeyDown("x") && textRead && player.GetComponent<PlayerController>().enabled == true && waiting)
        {
            //mostrar !
            timmy.GetComponent<TimmySideToSide>().speed = 3;

         

            StartCoroutine(callTimmy());
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


    IEnumerator callTimmy()
    {

        waiting = false;
       
            audio.Play();

            yield return new WaitForSeconds(0.4f);

        waiting = true;




    }

}
