using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI, mute, sound, music, pause;
    [SerializeField] Slider volumeSlider;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
        if (volumeSlider.value == 0f)
        {
            Mute();
        }
        if (volumeSlider.value != 0f)
        {
            sound.SetActive(false);
            mute.SetActive(true);
            music.SetActive(true);
        }
    }

    public void Resume()
    {
        pause.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pause.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    } 

    public void Mute()
    {
        sound.SetActive(true);
        mute.SetActive(false);
        // music.SetActive(false);
        //AudioListener.volume = 0f;
        volumeSlider.value = 0f;
    }

    public void Sound()
    {
        sound.SetActive(false);
        mute.SetActive(true);
        music.SetActive(true);
        //AudioListener.volume = 1f;
        volumeSlider.value = 1f;

    }

    public void home()
    {
        Resume();
        SceneManager.LoadScene("Start");
    }
}
