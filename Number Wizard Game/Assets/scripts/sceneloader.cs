﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneloader : MonoBehaviour
{
public void LoadNextScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex+1);


    }
public void QuitGame()
    {
        Application.Quit();
    }



}
