using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Record : MonoBehaviour
{
    int  points;
    public Text gameOverText;
    public static int record = 0;
    void Start()
    {
        points = PlayerPrefs.GetInt("puntuacion");
        record = PlayerPrefs.GetInt("record");
    }

    // Update is called once per frame
    void Update()
    {
        if (points > record)
        {
            PlayerPrefs.SetInt("record", points);
            record = points;
            gameOverText.text = "Puntos: " + points.ToString() + "      Record:" + record.ToString();
            PlayerPrefs.SetInt("puntuacion", 0);
        }
        if (points <= record)
        {
            gameOverText.text = "Puntos: " + points.ToString() + "      Record:" + record.ToString();
            PlayerPrefs.SetInt("puntuacion", 0);
        }
    }
}
