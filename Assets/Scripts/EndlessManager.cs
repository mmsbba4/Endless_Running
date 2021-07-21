using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessManager : MonoBehaviour
{
    public static EndlessManager instance;
    public GameObject[] road_list;
    public Queue<GameObject> in_used = new Queue<GameObject>();
    private void Awake()
    {
        instance = this;
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
