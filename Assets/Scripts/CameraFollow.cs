﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player_target;
    public float offset;
    public float follow_radius;
    public Camera cam;
    private void Start()
    {
        OnStartGame();
    }
    void OnDeath()
    {

        StartCoroutine(Smoth_value(15, 10, 1f));
    }
    IEnumerator Smoth_value(float start, float end, float time)
    {
        cam.orthographicSize = start;
        var t = 0f;
        while (t < time)
        {
            t += Time.deltaTime / time;
            cam.orthographicSize = Mathf.Lerp(start, end, t);
            yield return null;
        }
    }
    Vector3 follow_pos = new Vector3();
    private void Update()
    {
        if (transform.position.x - follow_radius > player_target.position.x || transform.position.x + follow_radius < player_target.position.x)
        {
            follow_pos = new Vector3( player_target.position.x, transform.position.y,follow_pos.z);
        }
        if (transform.position.z - follow_radius > player_target.position.z || transform.position.z + follow_radius < player_target.position.z)
        {
            follow_pos = new Vector3(follow_pos.x, transform.position.y, player_target.position.z);
        }
        transform.position = Vector3.Lerp(transform.position, follow_pos, Time.smoothDeltaTime);
    }
    void OnStartGame()
    {
        Smoth_value(10, 15, 1f);
    }

}