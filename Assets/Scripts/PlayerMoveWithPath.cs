using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerMoveWithPath : MonoBehaviour
{
    public UnityEvent OnComplete;
    public MovePath current_path;
    public float x;
    void Start()
    {
         current_process = move_position();
         current_path.OnStartPath.Invoke();
         StartCoroutine(current_process);
    }
    IEnumerator current_process;
    public float speed;
    int index = 0;
    IEnumerator move_position()
    {

        if (index < current_path.path.Count - 1)
        {
            transform.position = current_path.path[index].position;
            float time = 0;
            float distance = Vector3.Distance(current_path.path[index].position, current_path.path[index + 1].position);
            transform.rotation = Quaternion.LookRotation(current_path.path[index + 1].position - current_path.path[index].position);
            while (transform.position != current_path.path[index + 1].position)
            {
                time += Time.deltaTime/distance * speed;
                transform.position = Vector3.Lerp(current_path.path[index].position, current_path.path[index + 1].position, time);
                yield return null;
            }
            transform.position = current_path.path[index + 1].position;
            index++;
            current_process = move_position();
            StartCoroutine(current_process);
        }
        else
        {
            current_path.OnDonePath.Invoke();
            if (current_path.connected_path != null)
            {
                current_path = current_path.connected_path;
                index = 0;
                current_process = move_position();
                current_path.OnStartPath.Invoke();
                StartCoroutine(current_process);
            }
            else
            {
                LevelManager.instance.PlayerWin();
                OnComplete.Invoke();
            }
        }
    }
    void ForceChangePath(MovePath new_cuurent_path)
    {
        StopCoroutine(current_process);
        current_path = new_cuurent_path;
        StartCoroutine(SwitchLand());

    }
    public void StopMove()
    {
        StopCoroutine(current_process);
    }
    IEnumerator SwitchLand()
    {
            Vector3 start_pos = transform.position;
            float time = 0;
            float distance = Vector3.Distance(start_pos, current_path.path[0].position);
            while (transform.position != current_path.path[0].position)
            {
                time += Time.deltaTime / distance * speed;
                transform.position = Vector3.Lerp(start_pos, current_path.path[0].position, time);
                yield return null;
            }
            transform.position = current_path.path[0].position;
            index = 0;
            current_process = move_position();
            current_path.OnStartPath.Invoke();
            StartCoroutine(current_process);
    }
}
