using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);
    [SerializeField] float  destroyDelay = 0.5f;
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    bool hasPackage;

    // void OnCollisionEnter2D(Collision2D other) {
    //     Debug.Log("CollisionEnter2D");
    // }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage){
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            
            Destroy(other.gameObject, destroyDelay);

            Debug.Log("Package picked up.");
        }else if (other.tag == "Customer" && hasPackage){
            hasPackage = false;
            spriteRenderer.color = noPackageColor;

            Debug.Log("Package Delivered.");
        }
    }
}
