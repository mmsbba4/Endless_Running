using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;
    public CameraFollow cmr;
    public LevelManager lvm;
    public MovePath path;
    private void Awake()
    {
        player = Instantiate(Resources.Load("player_" + GameManager.instance.tmp_data.current_player ) as GameObject, transform.position, transform.rotation);
        cmr.player_target = player.transform;
        lvm.record = player.GetComponent<Distance_record>();
        player.GetComponent<PlayerMoveWithPath>().current_path = path;
    }
}
