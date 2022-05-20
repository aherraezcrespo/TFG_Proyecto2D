using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    
    void Start()
    {
        CoinController.points = 0;
        EnemyController.points = 0;
        PlayerControllerPurp.vida = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void seleccionarNivel()
    {
        PlayerPrefs.SetInt("muerto", 1);
        SceneManager.LoadScene("MenuSelection");
    }

    public void retroceder()
    {
        PlayerPrefs.SetInt("muerto", 1);
        SceneManager.LoadScene("Start");

    }
}
