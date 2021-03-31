using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public bool IsPlaying { get; set; } = false;

	[SerializeField] private GameObject mrFlap;				// Referencia al jugador.
	[SerializeField] private GameObject obstacleHolder;     // Referencia al padre de los obstáculos.

	[SerializeField] private RotationBehaviour cameraRotation, stageRotation;		// Referencia a la camara.

	public void StartGame()
	{
		mrFlap.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
		cameraRotation.enabled = true;
		stageRotation.enabled = true;
	}

    public void EndGame()
	{
		mrFlap.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
		
		mrFlap.GetComponent<MrFlap>().enabled = false;
		cameraRotation.enabled = false;
		stageRotation.enabled = false;
	}
}
