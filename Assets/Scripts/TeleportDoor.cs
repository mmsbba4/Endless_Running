using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportDoor : MonoBehaviour
{
    public type door_type;
    public TeleportDoor targetDoor;
    public UnityEvent on_return;
    public UnityEvent on_instance;
    public Transform spawn_point;
    public enum type
    {
        indoor,
        outdoor
    }

    public void TriggerDoor(Transform character)
    {
        if (door_type == type.indoor)
        {
            Return(character);
        }
    }
    public void Return(Transform character)
    {
        on_return.Invoke();
        character.transform.position = targetDoor.GetComponent<TeleportDoor>().spawn_point.position;
        character.transform.rotation = targetDoor.GetComponent<TeleportDoor>().spawn_point.rotation;
        targetDoor.Instance();
    }
    public void Instance()
    {
        on_instance.Invoke();
    }
}
