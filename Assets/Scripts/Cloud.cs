using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    float speed;
    public Transform CameraPerent;
    private void Start()
    {
        speed = Random.Range(0.8f, 1.2f);
    }
    void Update()
    {
        transform.Translate(-transform.forward * speed * Time.deltaTime);
        if (transform.position.z < CameraPerent.position.z - 40)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 100);
        }
    }
}
