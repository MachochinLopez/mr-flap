using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrFlap : MonoBehaviour
{
    private const float JUMP_FORCE = 30f;       // Fuerza de salto.
    private Rigidbody2D rb2d;                   // Referencia al RigidBody2D.

    // Referencia al script de estados del juego.
    private GameStatesManager gameStates;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource>();
        gameStates = GameStatesManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        // Cada que presione espacio o dé click...
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
		{
            // Si el juego está activo...
            if (!gameStates.IsPlaying)
            {
                // Inicia el juego.
                gameStates.StartGame();
		    }

            // Salta.
            Jump();
        }
    }

    /**
     * Comportamiento de salto.
     */
    private void Jump()
	{
        rb2d.velocity = Vector2.up * JUMP_FORCE;
	}

    /**
     * Define el comportamiento para cuando el jugador detecte una colisión.
     */
	private void OnCollisionEnter2D(Collision2D collision)
	{
        // Si topa con un obstáculo...
        if (collision.gameObject.layer == 10)
		{
            // Cambie el estado del juego.
            gameStates.EndGame();
		}

        // Si topa contra la meta...
        if (collision.gameObject.layer == 11)
        {
            // Cambie el estado del juego.
            lapsManager.IncreaseCount();
        }
    }
}
