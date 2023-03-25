using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Vector3 position;

    private void Awake()
    {
        position = transform.position;
    }

    private void Update()
    {
        Vector3 newPosition = new Vector3(position.x + speed * Time.deltaTime, position.y, position.z);
        position = newPosition;
        transform.position = newPosition;
    }

    private void FixedUpdate()
    {
    }
}
