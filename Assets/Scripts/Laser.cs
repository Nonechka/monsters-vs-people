using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("monsters"))
        {            
            Destroy(gameObject);           
        }
        if (collision.gameObject.CompareTag("monsters2"))
        {
            Destroy(gameObject);
        }
    }

}
