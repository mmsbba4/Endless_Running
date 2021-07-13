using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChoising : MonoBehaviour
{
    public GameObject[] marker_choised;
    public GameObject[] marker_locked;
    public int coin_for_unlock = 0;
    public UnityEngine.UI.Text coin_text, current_level;
    private void OnEnable()
    {
        GameManager.instance.OnUpdateData.AddListener(UpdateVisible);
        UpdateVisible();
    }

    void UpdateVisible()
    {
        coin_text.text = GameManager.instance.tmp_data.current_coin.ToString();
        current_level.text = "level " + GameManager.instance.tmp_data.last_level.ToString();
        foreach (var i in marker_choised)
        {
            i.SetActive(false);
        }
        marker_choised[GameManager.instance.tmp_data.current_player].SetActive(true);
        for (int i = 0; i < marker_locked.Length; i++)
        {
            if (!GameManager.instance.tmp_data.avalable_character.Contains(i))
            {
                marker_locked[i].SetActive(true);
            }
            else
            {
                marker_locked[i].SetActive(false);
            }
        }
        
    }
    public void UnlockRandom()
    {
        if (GameManager.instance.tmp_data.avalable_character.Count >= 20)
        {
            Log.instance.ShowLog("not have unable character !");
        }
        else
        {
            if (GameManager.instance.tmp_data.current_coin >= coin_for_unlock)
            {
                GameManager.instance.tmp_data.current_coin -= coin_for_unlock;
                GameManager.instance.tmp_data.avalable_character.Add(GetNotExist());
                UpdateVisible();
            }
            else
            {
                Log.instance.ShowLog("not enough coin");
            }
            
            
        }
    }
    public void PlayClick()
    {
        GameManager.instance.LoadLevel();
    }
    int GetNotExist()
    {
        int rd = Random.Range(0, marker_locked.Length);
        if (!GameManager.instance.tmp_data.avalable_character.Contains(rd))
        {
            return rd;
        }
        else
        {
            return GetNotExist();
        }
    }
    public void SelectObject(int index)
    {
        if (GameManager.instance.tmp_data.avalable_character.Contains(index))
        {
            GameManager.instance.SetPlayer(index);
            UpdateVisible();
        }
        else
        {
            Log.instance.ShowLog("Unusable character !");
        }
    }
}
