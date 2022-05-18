using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< HEAD
        if (collision.tag == "Player")
        {
            points += 5;
=======
        if (collision.tag == "Player") { 
>>>>>>> pablob
            Destroy(gameObject);
        }
    }
}
