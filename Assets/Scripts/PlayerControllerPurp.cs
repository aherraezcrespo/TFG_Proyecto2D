using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerPurp : MonoBehaviour
{
    private float speed = 5;
    private float movementX;
    private SpriteRenderer flipPlayer;
    private Rigidbody2D playerRb;
    private float jumbForce = 9;
    private bool isGround = true;
    private Animator animatorPlayerJump;
    private Animator animatorPlayerRun;
    public GameObject explosionPrefab;
    public GameObject cameraPlayer;

    public Text textoContador;
    private int puntuacion = 0;

    // Start is called before the first frame update
    void Start()
    {
        flipPlayer = GetComponent<SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();
        animatorPlayerRun = GetComponent<Animator>();
        animatorPlayerJump = GetComponent<Animator>();
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

        animatorPlayerRun.SetFloat("VelocidadMovimiento", Mathf.Abs(movementX));

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            animatorPlayerJump.SetTrigger("Jump");
            playerRb.AddForce(Vector2.up * jumbForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }

        if (collision.gameObject.tag == "Water")
        {
            cameraPlayer.transform.parent = null;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            cameraPlayer.transform.parent = null;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            puntuacion = puntuacion + 5;
            textoContador.text = "PUNTOS: " + puntuacion.ToString();
        }
    }
}
