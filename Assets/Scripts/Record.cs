using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Record : MonoBehaviour
{
    public static int  points = 0;
    public Text gameOverText;
    public static int record = 0;
    public static int muerto = 0;
    void Start()
    {
        points = PlayerPrefs.GetInt("puntuacion");
        record = PlayerPrefs.GetInt("record");
        if (points > record)
        {
            PlayerPrefs.SetInt("record", points);
            record = points;
            gameOverText.text = "Puntos: " + points.ToString() + "      Record:" + record.ToString();
            points = 0;
            PlayerPrefs.SetInt("puntuacion", 0);
        }
        if (points <= record)
        {
            gameOverText.text = "Puntos: " + points.ToString() + "      Record:" + record.ToString();
            points = 0;
            PlayerPrefs.SetInt("puntuacion", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        muerto = PlayerPrefs.GetInt("muerto");
    }
    public void reset()
    {
        if (muerto == 1)
        {
            points = 0;
            PlayerPrefs.SetInt("puntuacion", 0);
        }
    }

}
