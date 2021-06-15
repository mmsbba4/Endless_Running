using System.Collections;
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
        LevelManager.instance.OnStartLevel.AddListener(OnStartGame);
        LevelManager.instance.OnPlayerDeath.AddListener(OnDeath);
        LevelManager.instance.OnPlayerWin.AddListener(OnWin);
    }
    private void OnDestroy()
    {
        LevelManager.instance.OnStartLevel.RemoveListener(OnStartGame);
        LevelManager.instance.OnPlayerDeath.RemoveListener(OnDeath);
        LevelManager.instance.OnPlayerWin.AddListener(OnWin);
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
        transform.position = Vector3.Lerp(transform.position, follow_pos, Time.smoothDeltaTime * followSpeed);
    }
    public float followSpeed;
    void OnStartGame()
    {
        print("start game");
      StartCoroutine(Smoth_value(15, 25, 1f));
    }

}
