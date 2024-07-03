using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum GameStates { Title, Game, Pause };
    public GameStates state2 = GameStates.Title;
    public string state = "Title";

    private float Counter = 0;
    public GameObject Pause; // Referenz zum Pausenmenü

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (state == "Game")
        {
            Counter += Time.deltaTime;
            if (Counter > 15)
            {
                SceneManager.LoadScene("StartScreen");
                state = "Title";
                state2 = GameStates.Title;
                Counter = 0;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                PauseGame();
            }
        }
        else if (state == "Pause" && Input.GetKeyDown(KeyCode.Q))
        {
            ResumeGame();
        }
    }

    public static void GoToGame()
    {
        SceneManager.LoadScene("Game");
        Instance.state = "Game";
        Instance.state2 = GameStates.Game;
    }

    public static void GoToStartScreen()
    {
        SceneManager.LoadScene("StartScreen");
        Instance.state = "Title";
        Instance.state2 = GameStates.Title;
    }

    public static void PauseGame()
    {
        Instance.state = "Pause";
        Instance.state2 = GameStates.Pause;
        Time.timeScale = 0; // Spiel pausieren
        Instance.Pause.SetActive(true); // Pausenmenü anzeigen
    }

    public static void ResumeGame()
    {
        Instance.state = "Game";
        Instance.state2 = GameStates.Game;
        Time.timeScale = 1; // Spiel fortsetzen
        Instance.Pause.SetActive(false); // Pausenmenü verstecken
    }
}
