using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTimmy : MonoBehaviour
{

    //
    public GameObject player;

    public GameObject timmy;

    public GameObject texto;

    private bool playerInRange;

    private bool textRead;

    public float f;


    // Start is called before the first frame update
    void Start()
    {
        //sd
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {


            texto.SetActive(true);
            //texto
            textRead = true;
        }

        if (playerInRange && Input.GetKeyDown("x") && textRead)
        {
            //mostrar !
            timmy.GetComponent<TimmySideToSide>().speed = 3;

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
        yield return new WaitForSeconds(3.1f);

        gameObject.SetActive(false);

    }

}
