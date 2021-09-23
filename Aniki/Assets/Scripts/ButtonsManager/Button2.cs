using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{



    private bool playerInRange;

    public bool button2pressed;

    private float timer;

    private float fakeTimer;

    public float timerLimit;

    public GameObject button1;

    private bool buttonFakePressed;

    private bool timmyInRange;


    public GameObject marcador1;

    public GameObject marcador2;

    public GameObject marcador3;

    public AudioSource goodsound;

    public AudioSource badsound;

    //ss
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
        //when button 1 is pressed
        if (playerInRange && Input.GetKeyDown(KeyCode.Z) && button1.GetComponent<Button1>().button1pressed)
        {

            goodsound.Play();
            marcador2.SetActive(true);
            Debug.Log("Has pulsado dos botones a tiempo");
            button2pressed = true;

        }
        if (timmyInRange && Input.GetKeyDown(KeyCode.X) && button1.GetComponent<Button1>().button1pressed)
        {
            goodsound.Play();
            marcador2.SetActive(true);
            Debug.Log("Has pulsado dos botones a tiempo");
            button2pressed = true;

        }


        //when button 1 is not pressed

        if (playerInRange && Input.GetKeyDown(KeyCode.Z) && !button1.GetComponent<Button1>().button1pressed)
        {
            marcador1.SetActive(false);
            marcador2.SetActive(false);
            marcador3.SetActive(false);

            badsound.Play();
            Debug.Log("Has pulsado el boton 2 sin pulsar el 1");
            buttonFakePressed = true;

        }
        if (timmyInRange && Input.GetKeyDown(KeyCode.X) && !button1.GetComponent<Button1>().button1pressed)
        {

            Debug.Log("Has pulsado el boton 2 sin pulsar el 1");
            buttonFakePressed = true;
            marcador1.SetActive(false);
            marcador2.SetActive(false);
            marcador3.SetActive(false);

            badsound.Play();

        }


        if (buttonFakePressed)
        {


            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 77, 8, 255);
            fakeTimer += Time.deltaTime;

            if (fakeTimer >= timerLimit)
            {

                fakeTimer = 0;
                buttonFakePressed = false;

            }

            if (buttonFakePressed == false)
            {

                gameObject.GetComponent<SpriteRenderer>().color = new Color(28, 221, 47, 255);
            }

        }



        if (button2pressed)
        {


            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 77, 8, 255);
            timer += Time.deltaTime;

            badsound.Play();

            if (timer >= timerLimit)
            {

                timer = 0;
                button2pressed = false;

            }

            if (button2pressed == false)
            {

                gameObject.GetComponent<SpriteRenderer>().color = new Color(28, 221, 47, 255);
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            playerInRange = true;

        }


        if (other.gameObject.CompareTag("Timmy"))
        {
            timmyInRange = true;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            playerInRange = false;
        }

        if (other.gameObject.CompareTag("Timmy"))
        {
            timmyInRange = false;
        }

    }
}
