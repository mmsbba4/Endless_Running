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
            CurrentLvWin.text = "LEVEL " + (GameManager.instance.tmp_data.last_level + 1);
            CurrentLvSli.text = "lv." + (GameManager.instance.tmp_data.last_level + 1);
            NextLvSli.text = "lv." + (GameManager.instance.tmp_data.last_level + 2);
        }
        Coin.text = GameManager.instance.tmp_data.current_coin + "";
        OnStartLevel.Invoke();
        yield return new WaitForSecondsRealtime(1.5f);
        bg_music.Play();
    }
    private void Awake()
    {
        instance = this;
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
    public void PlayerWin()
    {
        GameManager.instance.AddLevel();
        int bunus_coin = Random.Range(0, 25);
        bonus_coin_t.text =  "+" +bunus_coin.ToString() + " BONUS LEVEL";
        colected_coin_t.text =  "+" +colected_coin;
        GameManager.instance.AddCoin(bunus_coin + colected_coin);
        OnPlayerWin.Invoke();
        bg_music.Stop();
        bg_music.pitch = 1;
        bg_music.Play();
    }
}
