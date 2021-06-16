using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
    public void HasUsed()
    {
        GetComponent<BoxCollider>().enabled = false;
    }
}
