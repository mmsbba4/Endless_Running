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
    public int current_max_level;
    public userdata tmp_data
    {
        get 
        { 
            return UserData; 
        }
        set
        {
            UserData = value;
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
    public bool endless_mode = false;
    
    private void Awake()
    {
        endless_mode = false;
        if (instance == null)
        {
            instance = this;
            
            LoadData();
            DontDestroyOnLoad(this);
            Application.targetFrameRate = 60;
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
        if (data_string == "")
        {
            tmp_data = new userdata();
        }
        else
        {
            tmp_data = JsonUtility.FromJson<userdata>(data_string);
        }
    }
    void SaveData()
    {
        string data_string = JsonUtility.ToJson(UserData);
        PlayerPrefs.SetString("data", data_string);
    }
    public static GameManager instance;
    public UnityEvent OnUpdateData;

    public void LoadLevel()
    {
        if(tmp_data.last_level < current_max_level)
        {
            General_canvas.instance.ShowLoadCanvas();
            SceneManager.LoadScene("game_" + tmp_data.last_level);
        }
        else
        {
            int last_lv = current_max_level - 1;
            General_canvas.instance.ShowLoadCanvas();
            SceneManager.LoadScene("game_" + last_lv);
        }
    }
    public void BackToMain()
    {
        General_canvas.instance.ShowLoadCanvas();
        SceneManager.LoadScene("start_scene");
        //BannerAdExample.instance.HideBannerAd();
    }
    public void EndLessMode()
    {
        if (tmp_data.last_level < current_max_level)
        {
            Log.instance.ShowLog("Please complete level " + current_max_level);
        }
        else
        {
            General_canvas.instance.ShowLoadCanvas();
            SceneManager.LoadScene("endless");
        }
    }
    public void BackToHome()
    {
        endless_mode = true;
        General_canvas.instance.ShowLoadCanvas();
        SceneManager.LoadScene("start_scene");
        //BannerAdExample.instance.HideBannerAd();
    }
}
[Serializable]
public class userdata
{
    public List<int> avalable_character;
    public int current_coin;
    public int last_level;
    public int current_player;
    public userdata()
    {
        avalable_character = new List<int>();
        avalable_character.Add(0);
        current_coin = 1000;
        last_level = 0;
        current_player = 0;
    }
}
