using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public Text Coin, CurrentLv, CurrentLvSli, NextLvSli,PercentFaild, CurrentLvWin;
    public Slider level_sli;
    public UnityEvent OnTouch;
    public static LevelManager instance;
    public UnityEvent OnPlayerDeath;
    public UnityEvent OnPlayerWin;
    public UnityEvent OnStartLevel;
    public float complete_time;
    private void Awake()
    {
        instance = this;
    }
    private void FixedUpdate()
    {
        level_sli.value = Time.time;
    }
    private void Start()
    {
        level_sli.maxValue = complete_time;
        Coin.text = GameManager.instance.tmp_data.current_coin+ "";
        CurrentLv.text = "LEVEL "+ (GameManager.instance.tmp_data.last_level+1);
        CurrentLvWin.text = "LEVEL " + (GameManager.instance.tmp_data.last_level + 1);
        CurrentLvSli.text = "lv." + (GameManager.instance.tmp_data.last_level + 1);
        NextLvSli.text = "lv." + (GameManager.instance.tmp_data.last_level + 2);
        OnStartLevel.Invoke();
    }
    public void Touch()
    {
        OnTouch.Invoke();
    }
    public void PlayClick()
    {
        GameManager.instance.LoadLevel();
    }
    public void PlayerDeath()
    {
        PercentFaild.text = (int)(complete_time/100f*level_sli.value) + "% FAILED!";
        OnPlayerDeath.Invoke();
    }
    public void PlayerWin()
    {
        OnPlayerWin.Invoke();
    }
}
