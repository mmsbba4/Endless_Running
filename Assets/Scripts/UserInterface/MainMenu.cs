using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
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
    public void RateClick()
    {
        if (!rate_link_click)
        {
            rate_link_click = true;
            StartCoroutine(GetRequest());
        }
    }
    bool rate_link_click = false;
    IEnumerator GetRequest()
    {
#if UNITY_ANDROID
        string link = "https://mmsbba4.github.io/storelink/android.html";
#elif UNITY_IOS
        string link = "https://mmsbba4.github.io/storelink/ios.html";
#endif
        using (WWW www = new WWW(link))
        {
            yield return www;
            Application.OpenURL(www.text);
            rate_link_click = false;
            print(www.text);
        }
    }
    bool click_my_game = false;
    public void MyClickGame()
    {
        if (!click_my_game)
        {
            click_my_game = true;
            StartCoroutine(GetRequest_MyGame());
        }
    }
    IEnumerator GetRequest_MyGame()
    {
#if UNITY_ANDROID
        string link = "https://mmsbba4.github.io/storelink/mygameandroid.html";
#elif UNITY_IOS
        string link = "https://mmsbba4.github.io/storelink/mygameios.html";
#endif
        using (WWW www = new WWW(link))
        {
            yield return www;
            Application.OpenURL(www.text);
            click_my_game = false;
            print(www.text);
        }
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
