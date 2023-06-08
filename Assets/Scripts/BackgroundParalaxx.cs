using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParalaxx : MonoBehaviour
{
    public float speed = 5f;
    public bool inGame;
    void Start()
    {
    }

    void Update()
    {
        if (inGame)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < -27.6f)
            {
                transform.position = new Vector3(22.6f, transform.position.y);
            }
        }
       
    }
}
