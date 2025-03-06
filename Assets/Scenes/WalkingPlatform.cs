using UnityEngine;

public class WalkingPlatform : MonoBehaviour
{
    public float moveSpeed = 5f;  // Szybkoœæ poruszania
    public float jumpForce = 7f;  // Si³a skoku
    private int jumpCount = 0;    // Liczba skoków
    private bool isGrounded;      // Sprawdzanie, czy gracz stoi na ziemi
    [SerializeField] private string groundTag = "Ground"; //Tag pod³ogi
    public int maxJumpCount = 2;  // Maksymalna liczba skoków (np. 2 dla podwójnego skoku)
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Pobieramy Rigidbody2D
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(groundTag))
        {
            isGrounded = true;
            jumpCount = 0;  // Resetujemy licznik skoków, gdy gracz dotknie ziemi
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(groundTag))
        {
            isGrounded = false;
        }
    }
    void Update()
    {
        // Poruszanie siê w lewo/prawo
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Skakanie
        if ((isGrounded || jumpCount < maxJumpCount) && Input.GetKeyDown(KeyCode.Space))
        {
            jumpCount++;  // Zwiêkszamy licznik skoków
            rb.velocity = new Vector2(rb.velocity.x, 0);  // Zatrzymujemy pionowy ruch przed nowym skokiem
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); //skaczemy
        }
    }
}

