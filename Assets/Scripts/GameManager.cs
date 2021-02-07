using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private int[] direction = new int[] { -1, 1 };
    private int randValue;
    private int value;

    // How much points the players need to win
    [SerializeField]
    private int points = 6;

    // Counter on how much points have been achieved
    private int scorePointTop = 0;
    private int scorePointBottom = 0;

    // If its 0 bottom player won
    // If its 1 top player won
    private int playerWins;

    // This text fields show the scores of the players
    [SerializeField]
    private Text topScore;
    [SerializeField]
    private Text bottomScore;

    // If the ball crosses on of these lines, player scores a point
    [SerializeField]
    private Transform endGameTop;
    [SerializeField]
    private Transform endGameBottom;

    // Takes the ball prefab
    [SerializeField]
    private GameObject ballPrefab;

    // BallController class for ballPrefab object
    private BallController ballController;

    // Get ball rigidbody
    private Rigidbody2D ballRb;

    // Saving the starting position of the ball
    private Vector2 startingPosition = new Vector2(0, 0);

    // Reference to the menu class
    private Menu gameMenu;

    // Properties
    public GameObject BallPrefab
    {
        get { return ballPrefab; }
        set { ballPrefab = value; }
    }

    public int PlayerWins
    {
        get { return playerWins; }
        set { playerWins = value; }
    }

    // Start function
    private void Start()
    {
        ballRb = ballPrefab.GetComponent<Rigidbody2D>();
        ballController = ballPrefab.GetComponent<BallController>();
        topScore.text = scorePointTop.ToString();
        bottomScore.text = scorePointBottom.ToString();
        gameMenu = FindObjectOfType<Menu>();
    }

    private void Update()
    {
        Restart();
        PlayerWin();
    }

    // Get new ball on field
    public void Restart()
    {
        if (ballPrefab.transform.position.y > endGameTop.position.y)
        {
            // Add a point and print score
            scorePointBottom++;
            PrintScore(scorePointBottom, bottomScore);

            // Reset ball
            ResetBallPosition();
        }
        else if (ballPrefab.transform.position.y < endGameBottom.position.y)
        {
            // Reset ball speed
            // Add a point and print score
            scorePointTop++;
            PrintScore(scorePointTop, topScore);

            // Ball on starting point
            ResetBallPosition();
        }
    }

    // We end the game and call the NewGame screen from Menu class
    // And also reset the points of both players
    public void PlayerWin()
    {
        // if player wins is 0, bottom player wins
        // if its 1, top player win
        if (scorePointBottom == points)
        {
            playerWins = 0;
            gameMenu.NewGame();
            ResetPoints();
        }
        else if (scorePointTop == points)
        {
            playerWins = 1;
            gameMenu.NewGame();
            ResetPoints();
        }
    }

    // Reset the points for both players
    public void ResetPoints()
    {
        scorePointTop = 0;
        PrintScore(scorePointTop, topScore);
        scorePointBottom = 0;
        PrintScore(scorePointBottom, bottomScore);
    }

    // Print score on screen
    public void PrintScore(int score, Text playerScore)
    {
        playerScore.text = "" + score.ToString();
    }

    // Reset the ball position to the startin point
    public void ResetBallPosition()
    {
        ballController.BallSpeed = 5;
        ballPrefab.transform.position = startingPosition;

        // Choosing ball direction when it resets with spaghetti code :)
        randValue = Random.Range(-1 , 1);
        if (randValue < 0)
            value = -1;
        else if (randValue > 0 || randValue == 0)
            value = 1;
        ballRb.velocity = new Vector2(Random.Range(-3,3), ballController.BallSpeed * value);
    }
}
