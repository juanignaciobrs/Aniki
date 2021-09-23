using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{



    private bool playerInRange;


    private bool timmyInRange;

    public bool button1pressed;

    private float timer;

    public float timerLimit;

    public GameObject Marcador1;

    public AudioSource goodsound;

    public AudioSource finishSound;

   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerInRange && Input.GetKeyDown(KeyCode.Z)){

            button1pressed = true;
            goodsound.Play();
        }
        if (timmyInRange && Input.GetKeyDown(KeyCode.X))
        {
            goodsound.Play();
            button1pressed = true;

        }

        if (button1pressed)
        {
            Marcador1.SetActive(true);

            finishSound.Play();



            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 77, 8, 255);
            timer += Time.deltaTime;

            if(timer >= timerLimit)
            {

                timer = 0;
                button1pressed = false;

            }

        if(button1pressed == false)
            {

                gameObject.GetComponent<SpriteRenderer>().color = new Color(28, 221, 47, 255);
            }

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag("Player"))
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

        if (other.gameObject.CompareTag("Player") )
        {

            playerInRange = false;
        }

        if (other.gameObject.CompareTag("Timmy"))
        {
            timmyInRange = false;
        }

    }
}
