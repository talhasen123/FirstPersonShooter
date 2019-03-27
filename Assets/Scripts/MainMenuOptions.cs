using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(2);
    }

    public void credits()
    {
        SceneManager.LoadScene(4);
    }
}
