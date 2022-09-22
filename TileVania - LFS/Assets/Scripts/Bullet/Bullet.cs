using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    PlayerMovement player;
    [SerializeField] Rigidbody2D myRigidbody2D;

    [SerializeField] float bulletSpeed = 20f;
    float xSpeed;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        myRigidbody2D.velocity = new Vector2(xSpeed, 0f);
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     Destroy(gameObject);
    // }

    void OnCollisionEnter2D(Collision2D other)
    {
//        if (other.gameObject.tag == "Player") { return; }

        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }
}
