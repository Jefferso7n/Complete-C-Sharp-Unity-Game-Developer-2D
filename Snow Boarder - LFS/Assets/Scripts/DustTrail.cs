using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustEffect;
    [SerializeField] Collider2D circleCollider; //Used to detect collision of the player's head,
    //if we don't use it, when the player's head collides with the ground, it will also play the dust effects

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground" && other.otherCollider.GetInstanceID() != circleCollider.GetInstanceID()){
            dustEffect.Play();
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Ground" && other.otherCollider.GetInstanceID() != circleCollider.GetInstanceID()){
            dustEffect.Stop();
        }
    }
}
