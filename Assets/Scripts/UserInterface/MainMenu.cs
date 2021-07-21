using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Text coin_text;
    public Text level_text;
    public GameObject tutorials;
    public AudioSource bgSound;
    bool is_started = false;
    IEnumerator Start()
    {
        is_started = false;
        yield return new WaitForSeconds(.5f);
        GameManager.instance.OnUpdateData.AddListener(UpdateVisible);
        UpdateVisible();
        yield return new WaitForSecondsRealtime(1.4f);
        bgSound.Play();
    }
    private void OnDestroy()
    {
        GameManager.instance.OnUpdateData.RemoveListener(UpdateVisible);
    }
    void UpdateVisible()
    {
        coin_text.text = GameManager.instance.tmp_data.current_coin.ToString();
        level_text.text = "Lv." + (int)(GameManager.instance.tmp_data.last_level + 1);
    }
    public void Endless()
    {
        
        if (GameManager.instance.tmp_data.last_level >= GameManager.instance.current_max_level)
        {
            GameManager.instance.endless_mode = true;
            tutorials.SetActive(true);
        }
        else
        {
            Log.instance.ShowLog("Please complete level 3");
        }
    }
    public void SettingPress()
    {
        General_canvas.instance.PressSetting();
    }
    public void ChoiseCharacter()
    {
        General_canvas.instance.PressChoiseCharacter();
    }
    public void Play()
    {
        GameManager.instance.endless_mode = false;
        tutorials.SetActive(true);
    }

    public void ClickToturial()
    {
        if (!is_started)
        {
            if (GameManager.instance.endless_mode)
            {
                StartCoroutine(StartEndless());
            }
            else
            {
                StartCoroutine(StartGame());
            }
            
        }
    }
    IEnumerator StartGame()
    {
        is_started = true;
        yield return new WaitForSeconds(1);
        GameManager.instance.LoadLevel();

    }
    IEnumerator StartEndless()
    {
        is_started = true;
        yield return new WaitForSeconds(1);
        GameManager.instance.EndLessMode();
    }
}
