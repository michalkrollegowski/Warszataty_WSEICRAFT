using UnityEngine;

public class IsoPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Pr�dko�� ruchu gracza
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Pobranie wej�cia od gracza
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Przekszta�cenie ruchu na uk�ad izometryczny
        movement = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        // Przemieszczanie gracza
        rb.velocity = movement * moveSpeed;
    }
}
