using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TunnelDeath1 : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform destination;

    public GameObject dialogue;




    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            //   SceneManager.LoadScene("TunnelDeath1");

            collision.transform.position = destination.position;
            dialogue.SetActive(true);
        }
 
    }
}
