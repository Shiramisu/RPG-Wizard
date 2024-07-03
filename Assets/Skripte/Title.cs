using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static GameManager;

public class Title : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void GoToGame()
    {
        GameManager.GoToGame();
    }

    public void NewGame()
    {
        Wizard.playerstats = new stats();
        GameManager.GoToGame();
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        GameManager.ResumeGame();
    }

    public void StartScreen()
    {
        GameManager.GoToStartScreen();
    }
}
