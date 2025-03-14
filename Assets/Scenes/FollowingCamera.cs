using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
  public Transform player;  // Referencja do obiektu gracza
    public Vector3 offset;    // Przesunięcie kamery względem gracza
    public float smoothSpeed = 0.125f;  // Szybkość wygładzania ruchu kamery

    void Start()
    {
        // Inicjalizowanie początkowego przesunięcia (jeśli nie zostało przypisane)
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

            // Wygładzanie przejścia do nowej pozycji kamery
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Ustawienie pozycji kamery
            transform.position = smoothedPosition;
        }
    }
}
