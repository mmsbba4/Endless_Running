using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingPanel : MonoBehaviour
{
    public AudioMixer sound;
    public Slider sound_sli, music_sli;
    bool is_music = true;
    bool is_sound = true;
    public void SetSound()
    {
        if (is_music)
        {
            sound_sli.value = 0;
            sound.SetFloat("sound_vol", -80.0f);
            is_music = false;
        }
        else
        {
            sound_sli.value = 1;
            sound.SetFloat("sound_vol", 0f);
            is_music = true;
        }
      //  
    }
   public void SetMusic()
    {
        if (is_sound)
        {
            music_sli.value = 0;
            sound.SetFloat("music_vol", -80.0f);
            is_sound = false;
        }
        else
        {
            music_sli.value = 1;
            sound.SetFloat("music_vol", 0f);
            is_sound = true;
        }
    }

}
