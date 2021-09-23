using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TMPro;
using System;

public class DialogueController : MonoBehaviour
{

    public TextMeshProUGUI textComponent;

    public string[] lines;

    public float textSpeed;

    public int index;

    public GameObject zPrefab;

    PlayerController player;

    public Rigidbody2D rb;

    private bool moving = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.enabled = false;
        rb.velocity = Vector2.zero; 
        rb.GetComponent<Animator>().SetBool("isWalkingRight", false);
        rb.GetComponent<Animator>().SetBool("isWalkingLeft", false);
        rb.GetComponent<Animator>().SetBool("isJumping", false);
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {

       
        
        rb.velocity = Vector2.zero;
      
       

        rb.GetComponent<Animator>().SetBool("isWalkingRight", false);
        rb.GetComponent<Animator>().SetBool("isWalkingLeft", false);
        rb.GetComponent<Animator>().SetBool("isJumping", false);

        if (Input.GetKeyDown("z"))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }

            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }


    void StartDialogue()
    {

        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);

        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            index = -1;
            player.enabled = true;
           
        }
    }

    private void OnEnable()
    {
        if (index == -1)
        {
            player.enabled = false;
     
            textComponent.text = string.Empty;
            index = 0;
            StartCoroutine(TypeLine());
        }
    }
}
