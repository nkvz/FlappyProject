using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player inspector")]
    public float jumpForce = 5f;
    public Rigidbody2D birdRigidbody;
    public Animator animator;
    public bool isDead = false;
    public bool inGame;

    public GameObject endWindow;

    public void Awake()
    {
        //Time.timeScale = 0f;
    }

    private void Start()
    {
        inGame = false;
        //Time.timeScale = 0f;
        birdRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        birdRigidbody.isKinematic = true;
        
    }


    private void Update()
    {
        if (isDead)
            return;

        if (inGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                birdRigidbody.velocity = Vector2.up * jumpForce;
                animator.SetTrigger("tap");
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
        {
            isDead = true;
            Destroy(gameObject);
            Debug.Log("DEAD");
            endWindow.SetActive(true);
        }
    }
}
