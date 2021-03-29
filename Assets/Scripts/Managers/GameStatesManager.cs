using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatesManager : MonoBehaviour
{
    /**************
     *  Singleton *
     **************/

    private static GameStatesManager instance;
    // Referencia singleton.
    public static GameStatesManager Instance
    {
        get { return instance; }
    }
    
    /***************
     *  Variables  *
     ***************/

    public bool IsPlaying { get; set; } = false;      // Indica si la partida está en curso.

    [SerializeField] private RotationBehaviour cameraRotation, stageRotation;      // Referencia al script que hace que gire la cámara.

    [SerializeField] private GameObject obstaclesHolder;         // Referencia a los obstáculos.
    [SerializeField] private GameObject mrFlap;                  // Referencia al jugador.
    [SerializeField] private GameObject gameOverDisplay;         // Referencia al UI, pantalla de Game Over.

    // Start is called before the first frame update
    void Awake()
    {
        // Si existe una instancia de este objeto...
        if (instance != null && instance != this)
        {
            // La destruye.
            Destroy(this.gameObject);
        }
        // Si no existe una instancia de este objeto...
        else
        {
            // La crea.
            instance = this;
        }
    }

    /**
     * Activa todos los elementos de acción para iniciar el juego.
     */
    public void StartGame()
	{
        // Activa los elementos de acción.
        obstaclesHolder.SetActive(true);
        mrFlap.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        cameraRotation.enabled = true;
        stageRotation.enabled = true;

        IsPlaying = true;
    }

    /**
     * Se ejecuta cuando el jugador se impacta contra un obstáculo.
     * Desactiva el movimiento en general y evita que el jugador siga saltando.
     */
    public void EndGame()
	{
        // Desactivamos todos los elementos de acción.
        mrFlap.GetComponent<MrFlap>().enabled = false;
        mrFlap.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        cameraRotation.enabled = false;
        stageRotation.enabled = false;

        IsPlaying = false;
      
        // Desactiva el movimiento de los obstáculos.
        foreach (ObstacleBehaviour obstacle in obstaclesHolder.transform.GetComponentsInChildren<ObstacleBehaviour>()) {
            obstacle.enabled = false;
        }

        // Activa el display de "¡Perdiste!" en la UI.
        gameOverDisplay.SetActive(true);
    }
}
