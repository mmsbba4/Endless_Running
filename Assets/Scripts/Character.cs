using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float jump_speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    Ray r;
    RaycastHit h;
    bool isGrounded()
    {
        r.origin = transform.position;
        r.direction = Vector3.down;
        if (Physics.Raycast(r, out h, 0.55f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y+jump_speed, rb.velocity.z);
        }
        rb.velocity = new Vector3(transform.forward.x * speed, rb.velocity.y, transform.forward.z * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 8)
        {
            if (isGrounded())
            {
                transform.rotation =    collision.transform.rotation;
            }
            collision.gameObject.GetComponent<ChangeDirection>().Trigger();
        }
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<TeleportDoor>().TriggerDoor(transform);
        }
    }
}
