using UnityEngine;


public class BallController : MonoBehaviour
{
    private GameObject player1;

    [SerializeField]
    private float ballSpeed = 5f;

    [SerializeField]
    private float ballMaxSpeed = 10f;

    [SerializeField]
    private float ballAccelaration = 1f;


    private Rigidbody2D rb;

    // Properties
    public float BallSpeed
    {
        get
        {
            return ballSpeed;
        }
        set
        {
            ballSpeed = value;
        }
    }

    //Executes at the start of the game
    private void Start()
    {
        player1 = GameObject.Find("Player1");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(player1.transform.position.x, ballSpeed * -1);
    }

    private void Update()
    {

    }

    //Check where the ball hits the paddle
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        // ascii art:
        // ||  1 <- Left side of racket
        // ||
        // ||  0 <- Middle of the racket
        // ||
        // || -1 <- Right side of racket
        return (ballPos.x - racketPos.x) / racketHeight;
    }

    //Collision code
    void OnCollisionEnter2D(Collision2D col)
    {
        // Hit the left Racket?
        if (col.gameObject.name == "Player1")
        {
            AccelarateBall();

            // Calculate hit Factor
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(x, (float)0.5).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
        }

        // Hit the right Racket?
        if (col.gameObject.name == "Player2")
        {
            AccelarateBall();

            // Calculate hit Factor
            float x = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.x);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(x, (float)-0.5).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
        }
    }

    public void AccelarateBall()
    {
        ballSpeed += ballAccelaration;
        if (ballSpeed > ballMaxSpeed)
            ballSpeed = ballMaxSpeed;
    }
}
