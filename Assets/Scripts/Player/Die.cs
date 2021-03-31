using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
	[SerializeField] private GameStateManager gsM;      // Referencia al game manager.

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer == 9)
		{
			gsM.EndGame();
		}
	}
}
