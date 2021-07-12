using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayTouch : MonoBehaviour
{

    private void Awake()
    {
        Button[] btn = GetComponentsInChildren<Button>();    
        foreach (var i in btn)
        {
            i.onClick.AddListener(()=> { PlayShort(); });
        }
    }
    public void PlayLong()
    {
        Touch_Sounds.instance.PlayLong();
    }
    public void PlayShort()
    {
        Touch_Sounds.instance.PlayShort();
    }

}
