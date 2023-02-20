using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPanel : Common
{
    public Slider slider_sound;
    public Slider slider_music;

    // 点击关闭按钮
    public void OnBtnCloseClick()
    {
        Hide();
    }

    // 调整音效大小
    public void OnSoundValueChange(float f)
    {
        // 1. 修改音量大小 TODO
        // 2. 保存数据
        PlayerPrefs.SetFloat(Const.SoundSliderValue, f);
        Debug.Log("sound.value: " + f);
    }

    // 调整背景音乐大小
    public void OnMusicValueChange(float f)
    {
        // 1. 修改音量大小 TODO
        // 2. 保存数据
        PlayerPrefs.SetFloat(Const.MusicSliderValue, f);
        Debug.Log("music.value: " + f);
    }

    // 重写继承自父类的Show方法，需要添加音效初始值
    public override void Show()
    {
        base.Show();
        // 对界面进行初始化
        slider_sound.value = PlayerPrefs.GetFloat(Const.SoundSliderValue, 0); // 若没有获取到，则默认值为0
        slider_music.value = PlayerPrefs.GetFloat(Const.MusicSliderValue, 0);

        Debug.Log("sound.value: " + slider_sound.value);
        Debug.Log("music.value: " + slider_music.value);
    }
}
