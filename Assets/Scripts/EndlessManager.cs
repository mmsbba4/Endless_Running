using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessManager : MonoBehaviour
{
    public static EndlessManager instance;
    public GameObject[] road_list;
    public Queue<GameObject> in_used = new Queue<GameObject>();
    public PlayerSpawn spawn;
    Distance_record record;
    PlayerMoveWithPath move;
    public int lv_1, lv_2, lv_3;
    private void Awake()
    {
        instance = this;
    }
    private void FixedUpdate()
    {
        if (record == null)
        { 
            record = spawn.player.GetComponent<Distance_record>();
            move = spawn.player.GetComponent<PlayerMoveWithPath>();
        }
        if (record.totalDistance < 750)
        {
            if (record.totalDistance < 500)
            {
                if (record.totalDistance < 200)
                {
                    move.speed = 6.5f;
                }
                else
                {
                    move.speed = lv_1;
                }
            }
            else
            {
                move.speed = lv_2;
            }
        }
        else
        {
            move.speed = lv_3;
        }

    }
    public void AddToQuery(GameObject gameobject)
    {
        in_used.Enqueue(gameobject);
        if (in_used.Count > 3)
        {
            GameObject des = in_used.Dequeue();
            print(des + " destroyed");
            Destroy(des);
        }
    }
}
