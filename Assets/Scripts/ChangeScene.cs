﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

	public void SwitchToFight()
    {
        SceneManager.LoadScene("GridScene");
    }

    public void SwitchToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    public void QuitButton()
    {
        Application.Quit();
    }

}
