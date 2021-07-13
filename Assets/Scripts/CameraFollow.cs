using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;
    public Transform player_target;
    public float follow_radius;
    public Camera cam;
    public float minX, maxX, minY, maxY;

    private void Awake()
    {
        instance = this;
    }
    IEnumerator Start()
    {
        LevelManager.instance.OnPlayerDeath.AddListener(OnDeath);
        LevelManager.instance.OnPlayerWin.AddListener(OnWin);
        yield return new WaitForSeconds(1.5f);
        OnStartGame();
    }
    private void OnDestroy()
    {
        LevelManager.instance.OnPlayerDeath.RemoveListener(OnDeath);
        LevelManager.instance.OnPlayerWin.AddListener(OnWin);
    }
    bool is_on_path = true;
    public void CompletePath()
    {
        is_on_path = false;
    }
    void OnDeath()
    {

        StartCoroutine(Smoth_value(25, 15, 1f));
    }
    void OnWin()
    {
        StartCoroutine(Smoth_value(25, 15, 1f));
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
        if (player_target == null) return;
        follow_pos = new Vector3(player_target.position.x, transform.position.y, player_target.position.z);
        Vector3 current_pos  = Vector3.Lerp(transform.position, follow_pos, Time.smoothDeltaTime * followSpeed);
        if (is_on_path)
        {
            transform.position = new Vector3(Mathf.Clamp(current_pos.x, minX, maxX), current_pos.y, Mathf.Clamp(current_pos.z, minY, maxY));
        }
        else
        {
            transform.position = current_pos;
        }
    }
    public float followSpeed;
    void OnStartGame()
    {
      StartCoroutine(Smoth_value(15, 25, 1f));
    }

}
