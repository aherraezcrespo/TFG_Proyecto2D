using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5;
    private float movementX;
    private SpriteRenderer flipPlayer;
    private Rigidbody2D playerRb;
    private float jumbForce = 7;
    private bool isGround = true;

    // Start is called before the first frame update
    void Start()
    {
        flipPlayer = GetComponent<SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movementX = Input.GetAxis("Horizontal");
        if (movementX > 0)
        {
            flipPlayer.flipX = false;
        }
        if (movementX < 0)
        {
            flipPlayer.flipX = true;
        }
        transform.position += new Vector3(movementX, 0, 0) * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            playerRb.AddForce(Vector2.up * jumbForce, ForceMode2D.Impulse);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }
}
