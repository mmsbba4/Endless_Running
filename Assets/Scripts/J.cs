using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J : MonoBehaviour
{

    public Rigidbody rb;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + 10, rb.velocity.z);
        }
    }
}
