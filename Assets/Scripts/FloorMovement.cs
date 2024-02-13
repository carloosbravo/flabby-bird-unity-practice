using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del suelo
    public float resetPosition = 10f; // Posición en la que se reinicia el suelo

    private float initialPosition;

    void Start()
    {
        initialPosition = transform.position.x; // Guarda la posición inicial del suelo
    }

    void Update()
    {
        // Mueve el suelo hacia la izquierda
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Si el suelo ha llegado a la posición de reinicio, vuelve a colocarlo al principio
        if (transform.position.x <= -resetPosition)
        {
            transform.position = new Vector2(initialPosition, transform.position.y);
        }
    }
}
