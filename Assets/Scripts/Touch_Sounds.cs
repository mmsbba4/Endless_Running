using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_Sounds : MonoBehaviour
{
    public static Touch_Sounds instance;
    public GameObject short_touch, long_touch;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this);
            }
        }
    }
    public float long_duration, short_duration;
    public void PlayLong()
    {
        Destroy(Instantiate(long_touch), long_duration);
    }
    public void PlayShort()
    {
        Destroy(Instantiate(short_touch), short_duration);
    }
}
