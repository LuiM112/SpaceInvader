using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private int timer;
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }

    public void toCredits()
    {
        SceneManager.LoadScene(2);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
