using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class CoinController : MonoBehaviour
{
    public static int points = 0;
    public Text pointsText;
    private AudioSource coinAudioSource;
    public AudioClip coin;

    // Start is called before the first frame update
    void Start()
    {
        coinAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            coinAudioSource.PlayOneShot(coin);
            points += 5;
            Destroy(gameObject);
        }
    }
}
