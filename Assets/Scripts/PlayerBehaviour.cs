using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player inspector")]
    public float jumpForce = 5f;
    private Rigidbody2D birdRigidbody;
    private Animator animator;
    private bool isDead = false;

    private void Start()
    {
        birdRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDead)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            birdRigidbody.velocity = Vector2.up * jumpForce;
            animator.SetTrigger("tap");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
        {
            isDead = true;
            Destroy(gameObject);
            Debug.Log("DEAD");
        }
    }
}
