using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private void LoadStarMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void LoadGame()
    {
        SceneManager.LoadScene("Game");

    }
    private void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}
