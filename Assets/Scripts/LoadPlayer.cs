using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadPlayer : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public Transform spawn;

    // Start is called before the first frame update
    void Start()
    {
        int selectedPlayer = PlayerPrefs.GetInt("selectedPlayer");
        switch (selectedPlayer)
        {
            case 0:
                GameObject dif1 = playerPrefabs[1];
                GameObject dif2 = playerPrefabs[2];
                // Destroy(dif1.gameObject);
                //Destroy(dif2.gameObject);
                //dif1.SetActive(false);
                //dif2.SetActive(false);
                
                break;
            case 1:
                GameObject dif3 = playerPrefabs[0];
                GameObject dif4 = playerPrefabs[2];
                //Destroy(dif3.gameObject);
                //Destroy(dif4.gameObject);
                //dif3.SetActive(false);
                //dif4.SetActive(false);
                break;
            case 2:
                GameObject dif5 = playerPrefabs[0];
                GameObject dif6 = playerPrefabs[1];
                // Destroy(dif5.gameObject);
                // Destroy(dif6.gameObject);
                //dif5.SetActive(false);
                //dif6.SetActive(false);
                break;
        }
        GameObject prefab = playerPrefabs[selectedPlayer];
        GameObject clone = Instantiate(prefab, spawn.position, Quaternion.identity);
    }

}
