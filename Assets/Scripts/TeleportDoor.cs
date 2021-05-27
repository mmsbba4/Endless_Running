using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportDoor : MonoBehaviour
{
    public type door_type;
    public TeleportDoor return_door;
    public UnityEvent on_return;
    public UnityEvent on_instance;
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
        character.transform.position = return_door.transform.position;
        character.transform.rotation = return_door.transform.rotation;
        return_door.Instance();
    }
    public void Instance()
    {
        on_instance.Invoke();
    }
}
