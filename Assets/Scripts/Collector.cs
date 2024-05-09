using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    // Start is called before the first frame update

 
    private void OnTriggerEnter2D(Collider2D collision)// π÷ŒÔ ’ºØ∆˜
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
            Destroy(collision.gameObject);
    }
}
