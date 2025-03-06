using UnityEngine;

public class WalkingPlatform : MonoBehaviour
{
    public float moveSpeed = 5f;  // Szybko�� poruszania
    public float jumpForce = 7f;  // Si�a skoku
    private int jumpCount = 0;    // Liczba skok�w
    private bool isGrounded;      // Sprawdzanie, czy gracz stoi na ziemi
    [SerializeField] private string groundTag = "Ground"; //Tag pod�ogi
    public int maxJumpCount = 2;  // Maksymalna liczba skok�w (np. 2 dla podw�jnego skoku)
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
            jumpCount = 0;  // Resetujemy licznik skok�w, gdy gracz dotknie ziemi
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
        // Poruszanie si� w lewo/prawo
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Skakanie
        if ((isGrounded || jumpCount < maxJumpCount) && Input.GetKeyDown(KeyCode.Space))
        {
            jumpCount++;  // Zwi�kszamy licznik skok�w
            rb.velocity = new Vector2(rb.velocity.x, 0);  // Zatrzymujemy pionowy ruch przed nowym skokiem
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); //skaczemy
        }
    }
}

