using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
  public Transform player;  // Referencja do obiektu gracza
    public Vector3 offset;    // Przesuni�cie kamery wzgl�dem gracza
    public float smoothSpeed = 0.125f;  // Szybko�� wyg�adzania ruchu kamery

    void Start()
    {
        // Inicjalizowanie pocz�tkowego przesuni�cia (je�li nie zosta�o przypisane)
        if (player != null)
        {
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Obliczanie nowej pozycji kamery (na tej samej osi Y, co gracz, ale z offsetem X i Z)
            Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

            // Wyg�adzanie przej�cia do nowej pozycji kamery
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Ustawienie pozycji kamery
            transform.position = smoothedPosition;
        }
    }
}
