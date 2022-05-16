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
    private Vector3 start, end;

    // Start is called before the first frame update
    void Start()
    {
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
}
