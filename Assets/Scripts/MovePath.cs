using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MovePath : MonoBehaviour
{
    public UnityEvent OnStartPath;
    public UnityEvent OnDonePath;
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
    private void Start()
    {
        SpawnCoin();
    }
    void SpawnCoin()
    {
        if (path.Count > 1)
        {
            for (int i = 0; i < path.Count - 1; i++)
            {
                int coin_count = Random.Range(0,2);
                if (coin_count > 0)
                {
                    Vector3 pos = Vector3.Lerp(path[i].position, path[i + 1].position, Random.Range(0.0f,1.0f));
                    Instantiate(Resources.Load("road_coin"), new Vector3(pos.x, 0.3f, pos.z), Quaternion.LookRotation(path[i].position - path[i + 1].position));
                }
            }
        }
    }
}
