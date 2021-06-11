using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Text coin_text;
    public Text level_text;
    public int max_current_level;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);
        GameManager.instance.OnUpdateData.AddListener(UpdateVisible);
        UpdateVisible();
    }
    private void OnDestroy()
    {
        GameManager.instance.OnUpdateData.RemoveListener(UpdateVisible);
    }
    void UpdateVisible()
    {
        coin_text.text = GameManager.instance.tmp_data.current_coin.ToString();
        level_text.text = GameManager.instance.tmp_data.last_level.ToString();
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
    public void Play()
    {

    }

}
