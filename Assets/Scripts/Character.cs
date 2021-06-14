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
        LevelManager.instance.OnTouch.AddListener(Touch);
    }
    private void OnDestroy()
    {
        LevelManager.instance.OnTouch.RemoveListener(Touch);
    }
    Ray r;
    RaycastHit h;
    bool isGrounded()
    {
        r.origin = transform.position;
        r.direction = Vector3.down;
        if (Physics.Raycast(r, out h, 1.1f))
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
        rb.velocity = new Vector3(transform.forward.x * speed, rb.velocity.y, transform.forward.z * speed);
    }
    public void Touch()
    {
        if (isGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + jump_speed, rb.velocity.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 8)
        {
            if (isGrounded())
            {
                transform.rotation = collision.transform.rotation;
            }
            collision.gameObject.GetComponent<ChangeDirection>().Trigger();
        }
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<TeleportDoor>().TriggerDoor(transform);
        }
        if (collision.gameObject.layer == 4)
        {
            Death();
        }
        if (collision.gameObject.layer == 10)
        {
            Win();
        }
    }
    void Win()
    {
        print("win");
        LevelManager.instance.PlayerWin();
    }
    void Death()
    {
        
        LevelManager.instance.PlayerDeath();
        Destroy(gameObject);
    }
}
