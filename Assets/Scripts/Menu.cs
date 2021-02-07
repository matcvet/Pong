using UnityEngine;



public class Menu : MonoBehaviour
{
    // Wait screen...
    [SerializeField]
    private GameObject waitScreen;

    // Who won text field
    [SerializeField]
    private GameObject topWinsText;
    [SerializeField]
    private GameObject bottomWinsText;

    // Player score text fields
    [SerializeField]
    private GameObject scoreTextTop;
    [SerializeField]
    private GameObject scoreTextBottom;

    [SerializeField]
    private GameObject pauseScreen;

    // flag to determine if we are waiting for uset input to start game
    private bool waitingToStartGame = true;

    private GameManager gm;
    private int win;

    private bool gamePause = false;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0f;

        gm = FindObjectOfType<GameManager>();

        if (waitScreen != null)
        {
            waitScreen.SetActive(true);
        }
        else
        {
            waitingToStartGame = false;
            Debug.LogError("waitScreen was not set in the inspector. Please set and try again");
        }
    }

    private void Update()
    {
        StartGame();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePause == false)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    // This is the start screen of the game
    public void StartGame()
    {
        // if the waitingToStartGame is enabled and the 'Space' key has been pressed
        if (waitingToStartGame && Input.GetKeyDown(KeyCode.Space))
        {
            // set the flag to false so that will no longer be checking for input to start game
            waitingToStartGame = false;
            if (waitScreen != null)
            {
                Time.timeScale = 1f;
                waitScreen.SetActive(false);
                bottomWinsText.SetActive(false);
                topWinsText.SetActive(false);
                scoreTextTop.SetActive(true);
                scoreTextBottom.SetActive(true);
            }
        }
    }

    // Same screen, but when a player wins
    public void NewGame()
    {
        Time.timeScale = 0f;
        waitScreen.SetActive(true);
        scoreTextTop.SetActive(false);
        scoreTextBottom.SetActive(false);
        waitingToStartGame = true;
        win = gm.PlayerWins;
        if (win == 1)
        {
            topWinsText.SetActive(true);
        }
        else
        {
            bottomWinsText.SetActive(true);
        }
    }

    // Pause the game
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
        scoreTextTop.SetActive(false);
        scoreTextBottom.SetActive(false);
        gamePause = true;
    }

    // Resume the game
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        scoreTextTop.SetActive(true);
        scoreTextBottom.SetActive(true);
        gamePause = false;
    }
}
