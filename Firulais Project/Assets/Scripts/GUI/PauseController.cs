﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    private bool paused;
    [SerializeField]
    public GameObject pauseMenu;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                ResumeGame();
            }
            else
            {
                paused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
	}


    public void ResumeGame()
    {
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}