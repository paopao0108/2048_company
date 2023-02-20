using System.Collections;
using System.Collections.Generic;
using Script.Constant;
using Script.View;
using UnityEngine;
using UnityEngine.UIElements;
using static Script.Constant.Constant;
using Slider = UnityEngine.UI.Slider;

public class SetPanel : Common
{
    public Slider soundSlider;
    public Slider musicSlider;
    public void OnSoundChange(float f)
    {
        PlayerPrefs.SetFloat(SoundValue, f);
    }
    
    public void OnMusicChange(float f)
    {
        Debug.Log("music: " + f);
        PlayerPrefs.SetFloat(MusicValue, f);
    }

    public void OnCloseClick()
    {
        base.Hide();
    }

    public override void Show()
    {
        base.Show();
        soundSlider.value = PlayerPrefs.GetFloat(SoundValue, 0);
        musicSlider.value = PlayerPrefs.GetFloat(MusicValue, 0);
    }
}
