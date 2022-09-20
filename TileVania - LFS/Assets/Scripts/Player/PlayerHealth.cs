using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] CapsuleCollider2D myBodyCollider2D;
    [SerializeField] Animator myAnimator;
    [SerializeField] Rigidbody2D myRigidbody2D;
    [SerializeField] CinemachineImpulseSource myImpulseSource;
    [SerializeField] Vector2 deathKick = new Vector2(20f, 20f);
    [SerializeField] float impulseForce = 1f;
    
    bool isALive = true;
    public bool IsALive { get => isALive; set => isALive = value; }

    void Start()
    {

    }


    void Update()
    {
        Die();
    }

    void Die()
    {
        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemies")))
        {
            IsALive = false;
            myRigidbody2D.velocity = deathKick;

            myAnimator.SetTrigger("Dying");
            myImpulseSource.GenerateImpulse(impulseForce);
        }
    }
}
