using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPanel : Common
{
    public Slider slider_sound;
    public Slider slider_music;

    // ����رհ�ť
    public void OnBtnCloseClick()
    {
        Hide();
    }

    // ������Ч��С
    public void OnSoundValueChange(float f)
    {
        // 1. �޸�������С TODO
        // 2. ��������
        PlayerPrefs.SetFloat(Const.SoundSliderValue, f);
        Debug.Log("sound.value: " + f);
    }

    // �����������ִ�С
    public void OnMusicValueChange(float f)
    {
        // 1. �޸�������С TODO
        // 2. ��������
        PlayerPrefs.SetFloat(Const.MusicSliderValue, f);
        Debug.Log("music.value: " + f);
    }

    // ��д�̳��Ը����Show��������Ҫ�����Ч��ʼֵ
    public override void Show()
    {
        base.Show();
        // �Խ�����г�ʼ��
        slider_sound.value = PlayerPrefs.GetFloat(Const.SoundSliderValue, 0); // ��û�л�ȡ������Ĭ��ֵΪ0
        slider_music.value = PlayerPrefs.GetFloat(Const.MusicSliderValue, 0);

        Debug.Log("sound.value: " + slider_sound.value);
        Debug.Log("music.value: " + slider_music.value);
    }
}
