﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void loadLastLevel()
    {
        string lastLevel = PlayerPrefs.GetString("LastLevel");
        SceneManager.LoadScene(lastLevel);
    }

    public void loadLevel1()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Maze1");
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void loadInstrunctions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void loadInstructions2()
    {
        SceneManager.LoadScene("Instructions2");
    }
    public void exitGame()
    {
        //note: app.quit will not run in the editor
        Application.Quit();
        Debug.Log("exitGame called");
    }
}
