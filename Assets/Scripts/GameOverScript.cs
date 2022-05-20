using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
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
}
