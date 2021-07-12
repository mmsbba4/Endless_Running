using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Text coin_text;
    public Text level_text;
    public int max_current_level;
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
        level_text.text ="Lv." + GameManager.instance.tmp_data.last_level.ToString();
    }
    public void Endless()
    {
        if (GameManager.instance.tmp_data.last_level >= max_current_level)
        {
            //go endless
        }
        else
        {
            Log.instance.ShowLog("complete maxLv first");
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
        tutorials.SetActive(true);
    }

    public void ClickToturial()
    {
        if (!is_started) StartCoroutine(StartGame());
    }
    IEnumerator StartGame()
    {
        is_started = true;
        yield return new WaitForSeconds(1);
        GameManager.instance.LoadLevel();
    }
}
