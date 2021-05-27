using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
    BoxCollider col;
    private void Start()
    {
        col = GetComponent<BoxCollider>();
    }
    public void Trigger()
    {
        StartCoroutine(disable());
    }
    IEnumerator disable()
    {
        col.enabled = false;
        yield return new WaitForSeconds(2);
        col.enabled = true;
    }
}
