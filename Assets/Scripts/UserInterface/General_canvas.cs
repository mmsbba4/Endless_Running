using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class General_canvas : MonoBehaviour
{
    public Text CountDowntext;
    public static General_canvas instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this);
            }
        }
    }
    IEnumerator CountDown()
    {
        CountDowntext.gameObject.SetActive(true);
        CountDowntext.text = "3";
        yield return new WaitForSecondsRealtime(1);
        CountDowntext.text = "2";
        yield return new WaitForSecondsRealtime(1);
        CountDowntext.text = "1";
        yield return new WaitForSecondsRealtime(1);
        CountDowntext.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public UnityEvent OnPressSetting;
    public UnityEvent OnPressCharacter;
    public void PressSetting()
    {
        OnPressSetting.Invoke();
    }
    public void OpenUI()
    {
        Time.timeScale = 0;
        wait_for_return = true;
    }
    bool wait_for_return = false;
    public void CloseUI()
    {
        if (wait_for_return)
        {
            StartCoroutine(CountDown());
            wait_for_return = false;
        }
        
    }
    public void PressChoiseCharacter()
    {
        OnPressCharacter.Invoke();
    }

}
