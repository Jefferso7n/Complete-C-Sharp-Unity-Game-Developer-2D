using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)){
            rb2D.AddTorque(torqueAmount);
        }else if (Input.GetKey(KeyCode.RightArrow)){
            rb2D.AddTorque(-torqueAmount);
        }
        
    }
}
