using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  
public class BilBoardText : MonoBehaviour
{
    public Text txt;
    void Start()
    {
        transform.LookAt(Camera.main.transform);
    }
    public void SetText(string number)
    {
        txt.text = number;
        Destroy(gameObject, 1);
    }

}
