using UnityEngine;

public class WalkingPlatform : MonoBehaviour
{
    public float moveSpeed = 5f;  // Szybkoœæ poruszania
    public float jumpForce = 7f;  // Si³a skoku
    private bool isGrounded;      // Sprawdzanie, czy gracz stoi na ziemi
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Pobieramy Rigidbody2D
    }

    void Update()
    {
        // Sprawdzanie, czy gracz dotyka ziemi (przytrzymanie przycisku skoku)
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        // Poruszanie siê w lewo/prawo
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Skakanie
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Dodajemy si³ê skoku
        }
    }
}

