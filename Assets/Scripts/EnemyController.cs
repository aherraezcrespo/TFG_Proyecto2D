using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float speed = 0.002f;
    private SpriteRenderer flipEnemy;
    private float movementX;
    public Transform target;
    private float speed2 = 0.005f;
    public GameObject explosionPrefab;
    private Vector3 start, end;
    private AudioSource enemyAudioSource;
    public AudioClip muerteEnemigo;
    
  
    // Start is called before the first frame update
    void Start()
    {
        enemyAudioSource = GetComponent<AudioSource>();
        flipEnemy = GetComponent<SpriteRenderer>();
        start = transform.position;
        end = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed + Time.deltaTime);
        if(transform.position == target.position)
        {
            if(target.position == end)
            {
                target.position = start;
            }
            else
            {
                target.position = end;
            }
        }
        if (transform.position.x < target.position.x)
        {
            flipEnemy.flipX = true;
        }
        else
        {
            flipEnemy.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyAudioSource.PlayOneShot(muerteEnemigo);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
