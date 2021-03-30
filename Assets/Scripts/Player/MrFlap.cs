using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrFlap : MonoBehaviour
{
    private const float JUMP_FORCE = 30f;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
		{
            Jump();
		}
    }

    private void Jump()
	{
        rb2d.velocity = new Vector2(0, JUMP_FORCE);
	}
}
