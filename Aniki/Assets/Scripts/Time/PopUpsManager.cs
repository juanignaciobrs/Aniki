using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpsManager : MonoBehaviour


{


    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;
    public GameObject text7;

    public GameObject cieling;


    public Transform target;
    public bool playerInRange;

    public AudioSource goodsound;

    // Start is called before the first frame update
    void Start()
    {
        //co
        StartCoroutine(playSounds());

    }

    // Update is called once per frame
    void Update()
    {
       if(playerInRange && Input.GetKeyDown("z"))
        {
            Debug.Log("Boton pulsado");

           

            cieling.GetComponent<Transform>().position = cieling.GetComponent<CielingMovement>().initialPosition;

        //    cieling.GetComponent<Transform>().Translate(cieling.GetComponent<CielingMovement>().initialPosition);

            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
            text5.SetActive(false);
            text6.SetActive(false);
            text7.SetActive(false);


            StopAllCoroutines();

            StartCoroutine(playSounds());

        }


    }

    IEnumerator playSounds()
    {
        goodsound.Play();
        yield return new WaitForSeconds(1);
        text1.SetActive(true);
        yield return new WaitForSeconds(4.4f);
        text2.SetActive(true);


        yield return new WaitForSeconds(5.0f);
        text3.SetActive(true);


        yield return new WaitForSeconds(5.0f);
        text4.SetActive(true);


        yield return new WaitForSeconds(3.1f);

        text5.SetActive(true);


        yield return new WaitForSeconds(1.8f);

        text6.SetActive(true);
        yield return new WaitForSeconds(1.4f);

        text7.SetActive(true);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {


            playerInRange = true;

           

        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {


            playerInRange = false;

           

        }

    }

}
