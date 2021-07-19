using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessManager : MonoBehaviour
{
    public static EndlessManager instance;
    public GameObject[] road_list;
    private void Awake()
    {
        instance = this;
    }

}
