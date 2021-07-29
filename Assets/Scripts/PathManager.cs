using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PathManager : MonoBehaviour
{
    public MovePath start_path;
    public MovePath end_path;
    public UnityEvent OnInitEndless;
    public UnityEvent OnStartSpawnNext;
    public Transform start_nextpath_point;
    public Door start_door, end_door;
    void Start()
    {
        //GameManager.instance.endless_mode = true;
        if (GameManager.instance.endless_mode)
        {
            start_path.OnStartPath.AddListener(on_start_path);
            start_path.OnStartPath.AddListener(start_door.Reasle);
            end_path.OnDonePath.AddListener(end_door.Hold);
            OnInitEndless.Invoke();
            EndlessManager.instance.AddToQuery(gameObject);
        }
        else
        {

            Destroy(this);
        }
    }
    void on_start_path()
    {
        OnStartSpawnNext.Invoke();
        GameObject next_path = Instantiate(EndlessManager.instance.road_list[Random.Range(0, EndlessManager.instance.road_list.Length)], start_nextpath_point.position, Quaternion.identity);
        end_path.connected_path = next_path.GetComponent<PathManager>().start_path;
    }
}
