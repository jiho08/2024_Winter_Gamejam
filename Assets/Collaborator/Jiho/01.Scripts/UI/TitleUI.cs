using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using Hellmade.Sound;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    [SerializeField] private List<CinemachineCamera> cameraList = new();
    [SerializeField] private List<Slider> sliderList = new();

    private void Start()
    {
        var masterValue = PlayerPrefs.GetFloat("Master", 0.5f);
        var musicValue = PlayerPrefs.GetFloat("Music", 0.5f);
        var effectValue = PlayerPrefs.GetFloat("Effect", 0.5f);

        sliderList[0].value = masterValue;
        sliderList[1].value = musicValue;
        sliderList[2].value = effectValue;
        
        EazySoundManager.GlobalVolume = masterValue;
        EazySoundManager.GlobalMusicVolume = musicValue;
        EazySoundManager.GlobalSoundsVolume = effectValue;
        EazySoundManager.GlobalUISoundsVolume = effectValue;
    }

    public void StartButton()
    {
        (cameraList[0].Priority, cameraList[2].Priority) = (cameraList[2].Priority, cameraList[0].Priority);
    }

    public void SettingButton()
    {
        (cameraList[0].Priority, cameraList[1].Priority) = (cameraList[1].Priority, cameraList[0].Priority);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        (cameraList[0].Priority, cameraList[1].Priority) = (cameraList[1].Priority, cameraList[0].Priority);
    }

    public void MasterSliderValueChanged(float value)
    {
        Debug.Log($"마스터 볼륨 : {value}");
        PlayerPrefs.SetFloat("Master", value);
        EazySoundManager.GlobalVolume = value;
    }

    public void MusicSliderValueChanged(float value)
    {
        Debug.Log($"뮤직 볼륨 : {value}");
        PlayerPrefs.SetFloat("Music", value);
        EazySoundManager.GlobalMusicVolume = value;
    }

    public void EffectSliderValueChanged(float value)
    {
        Debug.Log($"이펙트 볼륨 : {value}");
        PlayerPrefs.SetFloat("Effect", value);
        EazySoundManager.GlobalSoundsVolume = value;
        EazySoundManager.GlobalUISoundsVolume = value;
    }
}