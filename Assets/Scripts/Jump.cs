using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Animator m_anim;
    public Rigidbody rb;
    public bool Is_grounded = true;
    public float jump_speed = 15;
    public PlayerMoveWithPath player_move;
    void Start()
    {
        LevelManager.instance.OnTouch.AddListener(Touch);
        shadow.transform.localPosition = new Vector3(0,-0.95f,0);
    }
    private void OnDestroy()
    {
        LevelManager.instance.OnTouch.RemoveListener(Touch);
    }
    void Touch()
    {
        if (Time.timeScale != 1) return;
        if (Is_grounded)
        {
            m_anim.SetTrigger("jump");
            is_jump = true;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + jump_speed, rb.velocity.z);
            Destroy(Instantiate(Resources.Load("short_touch")), 0.2f);
        }
        else
        {
            if (is_jump)
            {
                m_anim.SetTrigger("double_jump");
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + jump_speed, rb.velocity.z);
                is_jump = false;
                Destroy(Instantiate(Resources.Load("long_touch")), 0.3f);
            }
        }
        
    }
    bool is_jump;
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            Is_grounded = false;
            m_anim.SetBool("is_grounded", Is_grounded);
            print("Grounded :" + Is_grounded);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            is_jump = false;
            Is_grounded = true;
            m_anim.SetBool("is_grounded", Is_grounded);
            print("Grounded :" + Is_grounded);
        }
        if (collision.gameObject.layer == 4)
        {
            Death();
            Instantiate(Resources.Load("die_effect") as GameObject, collision.contacts[0].point, Quaternion.identity);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            Is_grounded = true;
            m_anim.SetBool("is_grounded", Is_grounded);
        }
    }
    public void Win()
    {
        m_anim.SetTrigger("done");
        m_anim.SetBool("is_running", false);
    }
    public GameObject shadow;
    void Death()
    {
        Destroy(shadow);
        player_move.StopMove();
        LevelManager.instance.PlayerDeath();
        Destroy(gameObject);
    }
}
