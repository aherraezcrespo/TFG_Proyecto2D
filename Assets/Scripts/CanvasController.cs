using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void mundo1Completado()
    {
        SceneManager.LoadScene("Winter");
    }
    public void mundo2Completado()
    {
        SceneManager.LoadScene("Spring");
    }

    public void seleccionarNivel()
    {
        SceneManager.LoadScene("MenuSelection");
    }

    public void retroceder()
    {
        SceneManager.LoadScene("Start");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
