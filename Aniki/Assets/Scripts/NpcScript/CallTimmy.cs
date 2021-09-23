using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTimmy : MonoBehaviour
{

    bool waiting = true;

    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("x") && waiting)
        {
    



            StartCoroutine(callTimmy());
        }

    }


    IEnumerator callTimmy()
    {

        waiting = false;

        audio.Play();

        yield return new WaitForSeconds(0.2f);

        waiting = true;




    }


}
