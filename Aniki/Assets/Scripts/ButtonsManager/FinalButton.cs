using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalButton : MonoBehaviour
{



    private bool playerInRange;

    public bool finalButtonPressed;

    private float timer;

    private float fakeTimer;

    public float timerLimit;

    public GameObject button3;

    public GameObject wall;

    public GameObject text;

    private bool buttonFakePressed;

    public AudioSource rock;

    public GameObject message;

    public GameObject player;

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
        if (playerInRange && Input.GetKeyDown(KeyCode.Z) && button3.GetComponent<Button3>().button3pressed)
        {

            Debug.Log("Has pulsado los cuatro botones a tiempo y la puerta se abre");
            finalButtonPressed = true;

            wall.SetActive(false);

            text.SetActive(false);

            StartCoroutine(win());
        }

        //when button 2 is not pressed

        if (playerInRange && Input.GetKeyDown(KeyCode.Z) && !button3.GetComponent<Button3>().button3pressed)
        {

            marcador1.SetActive(false);
            marcador2.SetActive(false);
            marcador3.SetActive(false);

            badsound.Play();
            Debug.Log("Lo has pulsado pero FAKE");
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



        if (finalButtonPressed)
        {


            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 77, 8, 255);
            timer += Time.deltaTime;

            if (timer >= timerLimit)
            {

                timer = 0;
                finalButtonPressed = false;

            }

            if (finalButtonPressed == false)
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

    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            playerInRange = false;
        }

    }

    IEnumerator win()
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<PlayerController>().enabled = false;

        player.GetComponent<Animator>().SetBool("isWalkingRight", false);
        player.GetComponent<Animator>().SetBool("isWalkingLeft", false);
        player.GetComponent<Animator>().SetBool("isJumping", false);
        rock.Play();

        yield return new WaitForSeconds(1.4f);

        message.SetActive(true);

        gameObject.SetActive(false);

    }


}