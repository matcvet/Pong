using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float paddleSpeed = 0.5f;

    private GameManager gm;
    private Rigidbody2D rb;

    private Rigidbody2D ballRb;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        ballRb = gm.BallPrefab.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        EnemyMove();
    }

    //Move the enemy racket
    public void EnemyMove()
    {
        rb.position = new Vector2(ballRb.position.x * paddleSpeed, rb.position.y);
    }
}
