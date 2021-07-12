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
            SaveData();
        }
    }

    public void AddCoin(int coin)
    {
        userdata dat = tmp_data;
        dat.current_coin += coin;
        tmp_data = dat;
    }
    public void AddLevel()
    {
        userdata dat = tmp_data;
        dat.last_level ++;
        tmp_data = dat;
    }
    public void SetPlayer(int player)
    {
        userdata dat = tmp_data;
        dat.current_player = player;
        tmp_data = dat;
    }
    private void Awake()
    {
        print("GameManager Awake");
        if (instance == null)
        {
            print("instance = " + gameObject.name);
            instance = this;
            LoadData();
            DontDestroyOnLoad(this);
        }
        else
        {
            if (instance != this) Destroy(this);
        }
    }
    void LoadData()
    {
        string data_string = PlayerPrefs.GetString("data");
        print("Load data =  " + data_string);
        UserData = JsonUtility.FromJson<userdata>(data_string);
    }
    void SaveData()
    {
        string data_string = JsonUtility.ToJson(UserData);
        print(data_string);
        PlayerPrefs.SetString("data", data_string);
    }
    public static GameManager instance;
    public UnityEvent OnUpdateData;

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
