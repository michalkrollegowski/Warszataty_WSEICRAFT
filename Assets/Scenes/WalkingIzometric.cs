using UnityEngine;

public class IsoPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Prêdkoœæ ruchu gracza
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Pobranie wejœcia od gracza
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Przekszta³cenie ruchu na uk³ad izometryczny
        movement = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        // Przemieszczanie gracza
        rb.velocity = movement * moveSpeed;
    }
}
