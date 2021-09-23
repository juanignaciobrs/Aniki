using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{

    private bool playerInRange;

    public GameObject dialogueBox;
    public Canvas canvas;

    private bool notRead = true;

   // public GameObject zKey;
    //private GameObject zPrefab;

    // Start is called before the first frame update
    void Start()
    {
    //    zPrefab = dialogueBox.GetComponent<DialogueController>().zPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && notRead)
        {
            dialogueBox.SetActive(true);

            notRead = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            playerInRange = true;
       //     zKey = Instantiate(zPrefab, this.transform.position + new Vector3(1, 1, 0), Quaternion.identity);
        }


    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            notRead = true;
            
          //  Destroy(zKey);

        }
        

    }
}
