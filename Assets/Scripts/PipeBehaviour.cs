using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBehaviour : MonoBehaviour
{
    public float speed = 5f;

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1f, rb.velocity.y);
    }
    /*
    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);
    }
    */
    void FixedUpdate()
    {
        transform.position += new Vector3(-1f, 0f, 0f) * Time.fixedDeltaTime; // Движение влево
    }

}
