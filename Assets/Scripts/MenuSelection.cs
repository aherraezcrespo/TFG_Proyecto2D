using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelection : MonoBehaviour
{
    public GameObject[] players;
    public int SelectedPlayer = 0;
    private AudioSource menuAudioSource;
    public AudioClip playerSelection;

    void Start()
    {
        menuAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void seleccionarNivel()
    {
        switch (this.gameObject.name)
        {
            case "ButtonPlayRed":
                SelectedPlayer = 0;
                PlayerPrefs.SetInt("selectedPlayer", SelectedPlayer);
                SceneManager.LoadScene(2, LoadSceneMode.Single);      
                break;
            case "ButtonPlayPur":
                SelectedPlayer = 1;
                PlayerPrefs.SetInt("selectedPlayer", SelectedPlayer);
                SceneManager.LoadScene(2, LoadSceneMode.Single);
                break;
            case "ButtonPlayGre":
                SelectedPlayer = 2;
                PlayerPrefs.SetInt("selectedPlayer", SelectedPlayer);
                SceneManager.LoadScene(2, LoadSceneMode.Single);
                break;
            case "ButtonRed":
                SelectedPlayer = 0;
                PlayerPrefs.SetInt("selectedPlayer", SelectedPlayer);
                SceneManager.LoadScene(2, LoadSceneMode.Single);
                break;
            case "ButtonPur":
                SelectedPlayer = 1;
                PlayerPrefs.SetInt("selectedPlayer", SelectedPlayer);
                SceneManager.LoadScene(2, LoadSceneMode.Single);
                break;
            case "ButtonGre":
                SelectedPlayer = 2;
                PlayerPrefs.SetInt("selectedPlayer", SelectedPlayer);
                SceneManager.LoadScene(2, LoadSceneMode.Single);
                break;
        }

        menuAudioSource.PlayOneShot(playerSelection);
    }
}
