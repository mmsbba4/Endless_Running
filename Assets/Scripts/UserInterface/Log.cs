using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Log : MonoBehaviour
{
    public static Log instance;
    public Image[] UIElement;
    public Color[] UIRootColor;
    public Text log_text;
    public Color alpha;
    public GameObject LogParent;
    private void Start()
    {
        instance = this;
        List<Color> color_list = new List<Color>();
        foreach (var i in UIElement)
        {
            color_list.Add(i.GetComponent<Image>().color);
        }
        UIRootColor = color_list.ToArray();
    }
    public void ShowLog(string content)
    {
        StartCoroutine(ShowLogg(content));
    }
    public void ShowLog(string content, float time)
    {
        StartCoroutine(ShowLoggtime(content, time));
    }
    IEnumerator ShowLoggtime(string content, float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(ShowLogg(content));
    }
    IEnumerator ShowLogg(string content)
    {
        LogParent.SetActive(true);
        for (int i = 0; i< UIElement.Length; i++)
        {
            UIElement[i].color = alpha;
            UIElement[i].DOColor(UIRootColor[i], 0.1f);
        }
        yield return new WaitForSeconds(0.15f);
        log_text.text = content;
    }
    public void ClearLog()
    {
        StartCoroutine(ClearLogg());
    }
    IEnumerator ClearLogg()
    {
        log_text.text = "";
        for (int i = 0; i < UIElement.Length; i++)
        {
            UIElement[i].DOColor(alpha, 0.2f);
        }
        yield return new WaitForSeconds(0.25f);
        LogParent.SetActive(false);
    }
}
