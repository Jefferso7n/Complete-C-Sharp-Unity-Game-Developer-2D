using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRigidbody2D;

    [SerializeField] float moveSpeed = 1f;

    void Start()
    {

    }

    void Update()
    {
        myRigidbody2D.velocity = new Vector2(moveSpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!(LayerMask.LayerToName(other.gameObject.layer) == "Ground")) { return; }

        moveSpeed *= -1;
        FlipEnemyFacing();
    }

    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody2D.velocity.x)), 1f);
    }
}
