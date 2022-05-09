using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public void seleccionarNivel()
    {
        switch (this.gameObject.name)
        {
            case "ButtonPlaySpring":
                SceneManager.LoadScene("Spring");
                break;
            case "ButtonPlayAutumn":
                SceneManager.LoadScene("Autumn");
                break;
            case "ButtonPlayWinter":
                SceneManager.LoadScene("Winter");
                break;
        }
    }
}
