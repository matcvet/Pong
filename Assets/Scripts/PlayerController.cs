using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
    }

    // How to player is moving
    public void PlayerMovement()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y);
    }
}
