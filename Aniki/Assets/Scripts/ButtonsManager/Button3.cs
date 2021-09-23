using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3 : MonoBehaviour
{



    private bool playerInRange;

    public bool button3pressed;

    private float timer;

    private float fakeTimer;

    public float timerLimit;

    public GameObject button2;

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
        if (playerInRange && Input.GetKeyDown(KeyCode.Z) && button2.GetComponent<Button2>().button2pressed)
        {

            marcador3.SetActive(true);
            goodsound.Play();
            Debug.Log("Has pulsado tres botones a tiempo");
            button3pressed = true;

        }

        if (timmyInRange && Input.GetKeyDown(KeyCode.X) && button2.GetComponent<Button2>().button2pressed)
        {
            marcador3.SetActive(true);
            goodsound.Play();
            Debug.Log("Has pulsado tres botones a tiempo");
            button3pressed = true;

        }

        //when button 2 is not pressed

        if (playerInRange && Input.GetKeyDown(KeyCode.Z) && !button2.GetComponent<Button2>().button2pressed)
        {
            marcador1.SetActive(false);
            marcador2.SetActive(false);
            marcador3.SetActive(false);
            badsound.Play();
            Debug.Log("Has pulsado el boton 3 sin pulsar el 2 y/o el 1");
            buttonFakePressed = true;

        }
        if (timmyInRange && Input.GetKeyDown(KeyCode.X) && !button2.GetComponent<Button2>().button2pressed)
        {
            marcador1.SetActive(false);
            marcador2.SetActive(false);
            marcador3.SetActive(false);
            badsound.Play();
            Debug.Log("Has pulsado el boton 3 sin pulsar el 2 y/o el 1");
            buttonFakePressed = true;

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



        if (button3pressed)
        {


            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 77, 8, 255);
            timer += Time.deltaTime;
            badsound.Play();

            if (timer >= timerLimit)
            {

                timer = 0;
                button3pressed = false;

            }

            if (button3pressed == false)
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