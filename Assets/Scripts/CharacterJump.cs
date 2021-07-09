using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
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
        m_animator.SetBool("is_grounded", Is_grounded);
    }
    public bool is_jumped = false;
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
    }
    void Death()
    {

        LevelManager.instance.PlayerDeath();
        Destroy(gameObject);
    }
}
