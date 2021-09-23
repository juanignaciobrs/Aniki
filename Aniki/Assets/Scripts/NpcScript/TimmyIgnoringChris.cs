using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimmyIgnoringChris : MonoBehaviour
{



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        }


    }

}