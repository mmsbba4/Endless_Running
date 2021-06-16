using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePath : MonoBehaviour
{
    public List<Transform> path;
    public MovePath connected_path;
    private void OnDrawGizmos()
    {
        foreach (var i in path)
        {
            Gizmos.DrawSphere(i.position, 0.5f);
        }
        if (path.Count > 1)
        {
            for (int i =0; i< path.Count - 1; i++)
            {
                Gizmos.DrawLine(path[i].position, path[i+1].position);
            }
        }
    }
}
