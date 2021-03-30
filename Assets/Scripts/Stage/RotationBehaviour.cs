using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
