using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class PlayerControllerPurp : MonoBehaviour
{
    private float speed = 5;
    private float speedRestart = 100;
    private float movementX;
    private SpriteRenderer flipPlayer;
    private Rigidbody2D playerRb;
    private float jumbForce = 9;
    private bool isGround = true;
    private AudioSource playerAudioSourcePurp;
    public AudioClip jump;
    public AudioClip playerLose;
    public AudioClip ouch;
    public AudioClip coin;
    private Animator animatorPlayerJump;
    private Animator animatorPlayerRun;
    public GameObject explosionPrefab;
    public GameObject cameraPlayer;
    private int myDelay = 2000;
    public static int vida = 3;
    public static int puntuacion = 0;
    public static int last_puntuacion = 0;
    public Text textoContador;
    public CorazonesPurp vida_canvas;


    // Start is called before the first frame update
    void Start()
    {
        flipPlayer = GetComponent<SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();
        animatorPlayerRun = GetComponent<Animator>();
        animatorPlayerJump = GetComponent<Animator>();
        playerAudioSourcePurp = GetComponent<AudioSource>();
        textoContador.text = "PUNTOS: " + puntuacion.ToString();
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
            playerAudioSourcePurp.PlayOneShot(jump);    
            animatorPlayerJump.SetTrigger("Jump");
            playerRb.AddForce(Vector2.up * jumbForce, ForceMode2D.Impulse);
        }

        muertePlayer(vida);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }

        if (collision.gameObject.tag == "Water")
        {
            playerAudioSourcePurp.PlayOneShot(ouch);
            cameraPlayer.transform.parent = null;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            vida = 3;
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            playerAudioSourcePurp.PlayOneShot(ouch);
            vida -= 1;
            Debug.Log("Vida -> " + vida);
            vida_canvas.CambioVida(vida);
            if (vida <= 0)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                vida = 3;
                last_puntuacion = puntuacion;
                puntuacion = 0;
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Monster")
        {
            playerAudioSourcePurp.PlayOneShot(ouch);
            vida -= 1;
            Debug.Log("Vida -> " + vida);
            vida_canvas.CambioVida(vida);
            if (vida <= 0)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                vida = 3;
                last_puntuacion = puntuacion;
                puntuacion = 0;
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
                Destroy(gameObject);
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }

    private void muertePlayer(int vida)
    {
        if (vida == 0)
        {
            last_puntuacion = puntuacion;
            puntuacion = 0;
            vida = 5;
            CoinController.points = 0;
            EnemyController.points = 0;
            playerAudioSourcePurp.PlayOneShot(playerLose);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //Thread.Sleep(myDelay);
            cameraPlayer.transform.parent = null;
            //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            SceneManager.LoadScene("GameOver");
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            playerAudioSourcePurp.PlayOneShot(coin);
            puntuacion = puntuacion + 5;
            textoContador.text = "PUNTOS: " + puntuacion.ToString();
        }

        if (collision.gameObject.tag == "Monster")
        {
            puntuacion = puntuacion + 10;
            textoContador.text = "PUNTOS: " + puntuacion.ToString();
        }
    }
}
