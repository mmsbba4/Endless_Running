using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J : MonoBehaviour
{
    //public Animator m_anim;
    public Rigidbody rb;
    public bool Is_grounded = true;
    public float jump_speed;
    public PlayerMoveWithPath player_move;
    void Start()
    {
        LevelManager.instance.OnTouch.AddListener(Touch);
    }
    private void OnDestroy()
    {
        LevelManager.instance.OnTouch.RemoveListener(Touch);
    }
    void Touch()
    {
        if (Is_grounded)
        {
            //m_anim.SetTrigger("jump");
            is_jump = true;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + jump_speed, rb.velocity.z);
        }
        else
        {
            if (is_jump)
            {
               // m_anim.SetTrigger("double_jump");
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + jump_speed, rb.velocity.z);
                is_jump = false;
            }
        }
        
    }
    bool is_jump;
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            Is_grounded = false;
           // m_anim.SetBool("is_grounded", Is_grounded);
        }//
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 0)
        {
            is_jump = false;
            Is_grounded = true;
            //m_anim.SetBool("is_grounded", Is_grounded);
        }
        if (collision.gameObject.layer == 4)
        {
            Death();
        }
    }
    public void Win()
    {
        //m_anim.SetTrigger("win");
        LevelManager.instance.PlayerWin();
    }
    void Death()
    {
        player_move.StopMove();
        LevelManager.instance.PlayerDeath();
        Destroy(gameObject);
    }
}
