using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float jump_speed;
    public Animator m_animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LevelManager.instance.OnTouch.AddListener(Touch);
    }
    private void OnDestroy()
    {
        LevelManager.instance.OnTouch.RemoveListener(Touch);
    }

    public bool Is_grounded = true;

    void Update()
    {
        rb.velocity = new Vector3(transform.forward.x * speed, rb.velocity.y, transform.forward.z * speed);
        m_animator.SetBool("is_grounded", Is_grounded);
    }
  public  bool is_jumped = false;
    public void Touch()
    {
        if (Is_grounded)
        {
            is_jumped = true;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + jump_speed, rb.velocity.z);
            m_animator.SetTrigger("jump");
        }
        else
        {
            if (is_jumped)
            {
                is_jumped = false;
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + jump_speed, rb.velocity.z);
                m_animator.SetTrigger("double_jump");
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            Is_grounded = false;
            if (!is_jumped) is_jumped = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 0)
        {
            if (is_jumped) is_jumped = false;
            Is_grounded = true;
        }

        if (collision.gameObject.layer == 8)
        {
            if (Is_grounded)
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
        m_animator.SetTrigger("win");
        LevelManager.instance.PlayerWin();
    }
    void Death()
    {
        
        LevelManager.instance.PlayerDeath();
        Destroy(gameObject);
    }
}
