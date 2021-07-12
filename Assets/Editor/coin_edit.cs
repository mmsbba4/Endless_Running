using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class coin_edit : MonoBehaviour
{
    [MenuItem("Lake String/Add 1000 coin")]
    static void DoSomething()
    {
        GameManager.instance.AddCoin(1000);
    }
    [MenuItem("Lake String/Reset Coin")]
    static void ResetUserData()
    {
        GameManager.instance.tmp_data = new userdata();
    }
    [MenuItem("Lake String/Reset Level")]
    static void ResetLevel()
    {
        userdata dat = GameManager.instance.tmp_data;
        dat.last_level = 0;
        GameManager.instance.tmp_data = dat;
    }
}
