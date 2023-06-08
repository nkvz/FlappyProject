using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGround : MonoBehaviour
{
    public float speed = 1f; 
    public float changeDirectionInterval = 2f; 

    private float directionTimer; 
    private int currentDirection = 1; 

    private void Start()
    {
        directionTimer = changeDirectionInterval; 
    }

    private void Update()
    {
        directionTimer -= Time.deltaTime;

        if (directionTimer <= 0f)
        {
            currentDirection *= -1;

            directionTimer = changeDirectionInterval;
        }

        float newPosition = transform.position.x + speed * currentDirection * Time.deltaTime;

        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
    }
}
