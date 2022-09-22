using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;
    bool wasColleted = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!wasColleted)
        {
            wasColleted = true;

            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);

            Destroy(gameObject);
        }
    }
}
