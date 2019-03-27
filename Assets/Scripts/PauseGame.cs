using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject player;
    public bool paused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetButtonDown("Cancel"))
        {
            if ( !paused)
            {
                Time.timeScale = 0;
                paused = true;
                player.GetComponent<FirstPersonController>().enabled = false;
                pauseMenu.SetActive(true);
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1;
                paused = false;
                player.GetComponent<FirstPersonController>().enabled = true;
                pauseMenu.SetActive(false);
            }
        }
    }

    public void unPauseGame()
    {
        Time.timeScale = 1;
        paused = false;
        player.GetComponent<FirstPersonController>().enabled = true;
        pauseMenu.SetActive(false);
    }

    public void respawnGame()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
        paused = false;
        player.GetComponent<FirstPersonController>().enabled = true;
        pauseMenu.SetActive(false);
    }
}
