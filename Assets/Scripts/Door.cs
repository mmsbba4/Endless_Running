using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public ParticleSystem[] in_effect,out_effect;
    public void Hold()
    {
        foreach (var i in in_effect)
        {
            i.Play();
        }
    }
    public void Reasle()
    {
        print("Reasle");
        Destroy(Instantiate(Resources.Load("long_touch")), 0.5f);
        foreach (var i in out_effect)
        {
            i.Play();
        }
    }
}
