using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestAutumn : MonoBehaviour
{
    private Animator animatorChest;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        animatorChest = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animatorChest.SetTrigger("Open");
            SceneManager.LoadScene("Mundo1");
        }
    }
}
