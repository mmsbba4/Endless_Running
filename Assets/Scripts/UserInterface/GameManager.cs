using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private userdata UserData;
    public userdata tmp_data
    {
        get 
        { 
            return UserData; 
        }
        set
        {
            UserData = tmp_data;
            OnUpdateData.Invoke();
        }
    }

    public static GameManager instance;
    public UnityEvent OnUpdateData;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (instance != this) Destroy(this);
        }
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene("game_" + tmp_data.last_level);
    }
    public void BackToMain()
    {
        SceneManager.LoadScene("start_scene");
    }
    public void EndLessMode()
    {
        SceneManager.LoadScene("endless");
    }
}
[Serializable]
public class userdata
{
    public List<int> avalable_character;
    public int current_coin;
    public int last_level;
    public int current_player;
}
