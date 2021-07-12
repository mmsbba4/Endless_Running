using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BlurColor : MonoBehaviour
{
    public Image[] UIElement;
    public Text[] UItext;

    public Color[] UIRootColor;
    public Color[] UItextRootColor;

    public Color alpha;
    bool is_get_color = false;
    private void OnEnable()
    {
        if (!is_get_color)
        {
            UIElement = GetComponentsInChildren<Image>();
            List<Color> color_list = new List<Color>();
            foreach (var i in UIElement)
            {
                color_list.Add(i.GetComponent<Image>().color);
            }
            UIRootColor = color_list.ToArray();
            UItext = GetComponentsInChildren<Text>();
            List<Color> ColorText = new List<Color>();
            foreach (var i in UItext)
            {
                ColorText.Add(i.GetComponent<Text>().color);
            }
            UItextRootColor = ColorText.ToArray();
            is_get_color = true;
            StartCoroutine(Show());
        }
        else
        {
            StartCoroutine(Show());
        }

    }
    IEnumerator Show()
    {
        for (int i = 0; i < UIElement.Length; i++)
        {
            UIElement[i].color = alpha;
            Tweener n = UIElement[i].DOColor(UIRootColor[i], 0.25f);
            n.SetUpdate(true);
        }
        for (int i = 0; i < UItext.Length; i++)
        {
            UItext[i].color = alpha;
            Tweener n = UItext[i].DOColor(UItextRootColor[i], 0.25f);
            n.SetUpdate(true);
        }
        yield return null;
    }
    public void SetActiveToFalse()
    {
        StartCoroutine(Clear());
    }
    IEnumerator Clear()
    {
        for (int i = 0; i < UIElement.Length; i++)
        {
           Tweener n = UIElement[i].DOColor(alpha, 0.2f);
           n.SetUpdate(true);
        }
        for (int i = 0; i < UItext.Length; i++)
        {
           Tween n = UItext[i].DOColor(alpha, 0.2f);
            n.SetUpdate(true);
        }
        yield return new WaitForSeconds(0.25f);
        gameObject.SetActive(false);
    }
}
