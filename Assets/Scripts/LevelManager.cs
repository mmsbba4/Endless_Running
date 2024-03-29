﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public Text Coin, CurrentLv, CurrentLvSli, NextLvSli,PercentFaild, CurrentLvWin, bonus_coin_t, colected_coin_t;
    public Slider level_sli;
    public UnityEvent OnTouch;
    public static LevelManager instance;
    public UnityEvent OnPlayerDeath;
    public UnityEvent OnPlayerWin;
    public UnityEvent OnStartLevel;
    public float complete_time;
    public Distance_record record;
    public AudioSource bg_music;
    public int colected_coin;
    IEnumerator Start()
    {
        if (!GameManager.instance.endless_mode)
        {
            level_sli.maxValue = complete_time;
            CurrentLv.text = "LEVEL " + (GameManager.instance.tmp_data.last_level + 1);
            CurrentLvWin.text = "LEVEL " + (GameManager.instance.tmp_data.last_level +1);
            CurrentLvSli.text = "lv." + (GameManager.instance.tmp_data.last_level+1);
            NextLvSli.text = "lv." + (GameManager.instance.tmp_data.last_level + 2);
        }
        UpdateData();
        OnStartLevel.Invoke();
        yield return new WaitForSecondsRealtime(1.5f);
        bg_music.Play();
        GameManager.instance.OnUpdateData.AddListener(UpdateData);
    }
    private void OnDestroy()
    {
        GameManager.instance.OnUpdateData.RemoveListener(UpdateData);
    }
    private void Awake()
    {
        instance = this;
    }

    void UpdateData()
    {
        Coin.text = GameManager.instance.tmp_data.current_coin + "";
    }
    private void FixedUpdate()
    {
        if (!GameManager.instance.endless_mode)
            level_sli.value = record.totalDistance;
    }
    public void Touch()
    {
        OnTouch.Invoke();
    }
    
    public void SettingPress()
    {
        General_canvas.instance.PressSetting();
        General_canvas.instance.OpenUI();
    }
    public void CharacterPress()
    {
        General_canvas.instance.PressChoiseCharacter();
    }
    public void PlayClick()
    {
       GameManager.instance.LoadLevel();
    }
    public void PlayerDeath()
    {
        PercentFaild.text = (int)(level_sli.value/(complete_time / 100f)) + "% FAILED!";
        OnPlayerDeath.Invoke();
        bg_music.Stop();
        bg_music.pitch = 1;
        bg_music.Play();
    }
    public void RePlayEndless() 
    {
        GameManager.instance.EndLessMode();
    }
    public void Home()
    {
        GameManager.instance.BackToHome();
    }
    public int level_index;
    public void PlayerWin()
    {
        if (GameManager.instance.tmp_data.last_level == level_index) GameManager.instance.AddLevel();
        int bunus_coin = UnityEngine.Random.Range(0, 25);
        bonus_coin_t.text =  "+" +bunus_coin.ToString() + " BONUS LEVEL";
        colected_coin_t.text =  "+" +colected_coin;
        GameManager.instance.AddCoin(bunus_coin);
        OnPlayerWin.Invoke();
        bg_music.Stop();
        bg_music.pitch = 1;
        bg_music.Play();
        if (GameManager.instance.tmp_data.last_level == GameManager.instance.current_max_level)
        {
            try
            {
                Log.instance.ShowLog("Endless mode unlocked, try it !");
            }
            catch (Exception ex)
            {
                print(ex.Message);
            }
            
        }
    }
}
