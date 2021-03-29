using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;              // Velocidad a la que se mueve el obstáculo verticalmente.
    [SerializeField] private float movementDistance = 3f;           // Distancia que recorre el obstáculo verticalmente.

    private int direction;                                          // Dirección a la que iniciará moviéndose el obstáculo.

	private void Awake()
	{
        // Decide al azar si sube o baja.
        direction = Random.value >= 0.5f ? 1 : -1;
    }

	// Update is called once per frame
	private void Update()
    {
        // Devuelve la posición relativa al padre.
        float xPosition = transform.InverseTransformVector(transform.position).x;

        // Si supera el límite de movimiento...
        if (xPosition > movementDistance || xPosition < -movementDistance)
		{
            // Cambia la dirección.
            direction *= -1;
        }

        // Mueve el obstáculo a la velocidad y dirección determinada.
        transform.Translate(Vector3.right * movementSpeed * direction * Time.deltaTime);
    }
}
