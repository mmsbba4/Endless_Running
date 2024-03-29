﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance_record : MonoBehaviour
{
    public float totalDistance = 0;
    public bool record = true;
    private Vector3 previousLoc;
    void FixedUpdate()
    {
        if (record)
            RecordDistance();
    }
    void RecordDistance()
    {
        totalDistance += Vector3.Distance(transform.position, previousLoc);
        previousLoc = transform.position;
    }
}
