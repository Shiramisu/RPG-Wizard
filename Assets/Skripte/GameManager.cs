using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour // Deklariert die GameManager-Klasse, die von MonoBehaviour erbt
{
    public static GameManager Instance; // Statische Instanz der GameManager-Klasse, um Singleton-Verhalten zu erm�glichen

    private float timer; // Interner Timer zum Tracken der verbleibenden Zeit
    public float maxTime = 60f; // Maximale Zeit (in Sekunden), bevor das Spiel zur Startbildschirm-Szene zur�ckkehrt
    public enum GameState { Start, Game } // Definiert einen Enum-Typ namens GameState mit zwei m�glichen Zust�nden: Start und Game
    public GameState gameState; // Variable zur Speicherung des aktuellen Spielzustands

    public static stats playerStats; // Statische Variable zur Speicherung der Spieler-Stats

    private void Awake() // Unity-Methode, die beim Initialisieren des Spiels aufgerufen wird, vor Start
    {
        if (Instance == null) // Pr�ft, ob keine Instanz des GameManagers existiert
        {
            Instance = this; // Setzt die aktuelle Instanz als Singleton-Instanz
            DontDestroyOnLoad(gameObject); // Verhindert, dass das GameManager-Objekt beim Szenenwechsel zerst�rt wird

            // Initialisiere die statischen Variablen beim ersten Erstellen des Objekts
            playerStats = new stats();
        }
        else
        {
            Destroy(gameObject); // Zerst�rt das aktuelle GameManager-Objekt, wenn bereits eine Instanz existiert
            return; // Beendet die Ausf�hrung, um sicherzustellen, dass keine doppelten Instanzen verwendet werden
        }
    }

    private void Start() // Unity-Methode, die beim Start des Spiels aufgerufen wird
    {
        timer = maxTime; // Initialisiert den Timer mit der maximalen Zeit
        UpdateGameState(GameState.Start); // Setzt den Spielzustand auf Start
    }

    private void Update() // Unity-Methode, die in jedem Frame aufgerufen wird
    {
        if (gameState == GameState.Game) // �berpr�ft, ob der aktuelle Spielzustand Game ist
        {
            timer -= Time.deltaTime; // Reduziert den Timer um die vergangene Zeit seit dem letzten Frame
            if (timer <= 0) // �berpr�ft, ob der Timer abgelaufen ist
            {
                LoadStartScreen(); // L�dt die Startbildschirm-Szene
            }
        }
    }

    public void LoadGame() // Methode zum Laden der Game-Szene
    {
        SceneManager.LoadScene("Game"); // L�dt die Szene mit dem Namen "Game"
        UpdateGameState(GameState.Game); // Setzt den Spielzustand auf Game
        ResetTimer(); // Setzt den Timer zur�ck
    }

    public void NewGame() // Methode zum Starten eines neuen Spiels
    {
        // Setzt die Spieler-Stats zur�ck
        playerStats = new stats();
        LoadGame(); // L�dt die Game-Szene
    }

    public void QuitGame() // Methode zum Beenden des Spiels
    {
        Application.Quit(); // Beendet die Anwendung
    }

    private void LoadStartScreen() // Methode zum Laden der Startbildschirm-Szene
    {
        SceneManager.LoadScene("StartScreen"); // L�dt die Szene mit dem Namen "StartScreen"
        UpdateGameState(GameState.Start); // Setzt den Spielzustand auf Start
        ResetGameManager(); // Ruft die Methode auf, um den GameManager zur�ckzusetzen
    }

    private void ResetTimer() // Methode zum Zur�cksetzen des Timers
    {
        timer = maxTime; // Setzt den Timer auf die maximale Zeit zur�ck
    }

    private void UpdateGameState(GameState newState) // Methode zum Aktualisieren des Spielzustands
    {
        gameState = newState; // Aktualisiert den Spielzustand auf den neuen Zustand
    }

    private void ResetGameManager() // Methode zum Zur�cksetzen des GameManagers
    {
        timer = maxTime; // Setzt den Timer auf die maximale Zeit zur�ck
        UpdateGameState(GameState.Start); // Setzt den Spielzustand auf Start

        // Stellt sicher, dass die UI-Elemente wieder interaktiv sind
        GameObject startScreen = GameObject.Find("Canvas"); // Findet das Startbildschirm-Canvas-Objekt
        if (startScreen != null)
        {
            Button playButton = startScreen.transform.Find("Play").GetComponent<Button>(); // Findet die Play-Taste
            Button newGameButton = startScreen.transform.Find("NewGame").GetComponent<Button>(); // Findet die NewGame-Taste
            Button exitButton = startScreen.transform.Find("Quit").GetComponent<Button>(); // Findet die Exit-Taste

            if (playButton != null)
            {
                playButton.onClick.AddListener(LoadGame); // F�gt die LoadGame-Funktion zum OnClick-Event der Play-Taste hinzu
                playButton.interactable = true; // Macht die Play-Taste wieder interaktiv
            }
            if (newGameButton != null)
            {
                newGameButton.onClick.AddListener(NewGame); // F�gt die NewGame-Funktion zum OnClick-Event der NewGame-Taste hinzu
                newGameButton.interactable = true; // Macht die NewGame-Taste wieder interaktiv
            }
            if (exitButton != null)
            {
                exitButton.onClick.AddListener(QuitGame); // F�gt die QuitGame-Funktion zum OnClick-Event der Exit-Taste hinzu
                exitButton.interactable = true; // Macht die Exit-Taste wieder interaktiv
            }
        }
    }
}
