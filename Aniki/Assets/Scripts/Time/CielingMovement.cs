using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CielingMovement : MonoBehaviour
{



   public Rigidbody2D rb;

    private bool goingDown = true;

    public float speed;

    public Vector3 initialPosition;


    public GameObject popUpManager;

    public GameObject exit;

    public AudioSource angels;

    public GameObject finaltext;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = gameObject.transform.position;

      

    }

    // Update is called once per frame
    void Update()
    {

    
    }

    private void FixedUpdate()
    {

        if (goingDown)
        {
            rb.velocity = Vector2.down * speed;
        }

        if (!goingDown)
        {
            rb.velocity = Vector2.down * -speed;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            goingDown = false;
            //borrar los mensaje en pantalla
            popUpManager.GetComponent<PopUpsManager>().text1.SetActive(false);
            popUpManager.GetComponent<PopUpsManager>().text2.SetActive(false);
            popUpManager.GetComponent<PopUpsManager>().text3.SetActive(false);
            popUpManager.GetComponent<PopUpsManager>().text4.SetActive(false);
            popUpManager.GetComponent<PopUpsManager>().text5.SetActive(false);
            popUpManager.GetComponent<PopUpsManager>().text6.SetActive(false);
            popUpManager.GetComponent<PopUpsManager>().text7.SetActive(false);
            popUpManager.GetComponent<PopUpsManager>().enabled = false;
            exit.SetActive(false);
            //quitar la corrutina
            //quitar el muro que bloquea la salida

            angels.Play();

            finaltext.SetActive(true);

        }
    }



}
