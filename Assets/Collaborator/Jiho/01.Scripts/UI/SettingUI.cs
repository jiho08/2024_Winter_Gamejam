
using System;
using System.Collections.Generic;
using Hellmade.Sound;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SettingUI : UIToolkit
{
    [SerializeField] private AudioClip clickSound;
    
    private const string _optionStr = "Button_Option";
    private const string _exitStr = "Button_Exit";
    private const string _settingStr = "VisualElement_Setting";
    private const string _masterStr = "Slider_Master";
    private const string _musicStr = "Slider_Music";
    private const string _effectStr = "Slider_Effect";
    private const string _screenStr = "DropdownField_Screen";
    private const string _gameExitStr = "Button_GameExit";
    
    private Button _optionButton;
    private Button _exitButton;
    private Button _gameExitButton;

    private VisualElement _settingVisualElement;

    private Slider _masterVolumeSlider;
    private Slider _musicVolumeSlider;
    private Slider _effectVolumeSlider;

    private DropdownField _screenDropdownField;

    private void OnEnable()
    {
        GetUIElements();
        Initialize();
        
        _settingVisualElement.style.display = DisplayStyle.None;

        _optionButton.clicked += ClickOptionButton;
        _exitButton.clicked += ClickExitButton;
        _gameExitButton.clicked += ClickGameExitButton;
        
        _masterVolumeSlider.RegisterValueChangedCallback(MasterSlider);
        _musicVolumeSlider.RegisterValueChangedCallback(MusicSlider);
        _effectVolumeSlider.RegisterValueChangedCallback(EffectSlider);

        _screenDropdownField.RegisterValueChangedCallback(ScreenDropdown);
    }

    private void OnDisable()
    {
        _optionButton.clicked -= ClickOptionButton;
        _exitButton.clicked -= ClickExitButton;
        _gameExitButton.clicked -= ClickGameExitButton;
        
        _masterVolumeSlider.UnregisterValueChangedCallback(MasterSlider);
        _musicVolumeSlider.UnregisterValueChangedCallback(MusicSlider);
        _effectVolumeSlider.UnregisterValueChangedCallback(EffectSlider);

        _screenDropdownField.UnregisterValueChangedCallback(ScreenDropdown);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnOptionEvent();
        }
    }

    private void OnOptionEvent()
    {
        if (_settingVisualElement.style.display == DisplayStyle.Flex)
            ClickExitButton();
        else
            ClickOptionButton();
    }
    
    protected override void GetUIElements()
    {
        base.GetUIElements();
        
        _optionButton = root.Q<Button>(_optionStr);
        _exitButton = root.Q<Button>(_exitStr);
        _gameExitButton = root.Q<Button>(_gameExitStr);

        _settingVisualElement = root.Q<VisualElement>(_settingStr);

        _masterVolumeSlider = root.Q<Slider>(_masterStr);
        _musicVolumeSlider = root.Q<Slider>(_musicStr);
        _effectVolumeSlider = root.Q<Slider>(_effectStr);

        _screenDropdownField = root.Q<DropdownField>(_screenStr);
    }
    
    private void Initialize()
    {
        var masterValue = PlayerPrefs.GetFloat("Master", 0.5f);
        var musicValue = PlayerPrefs.GetFloat("Music", 0.5f);
        var effectValue = PlayerPrefs.GetFloat("Effect", 0.5f);
        
        EazySoundManager.GlobalVolume = masterValue;
        EazySoundManager.GlobalMusicVolume = musicValue;
        EazySoundManager.GlobalSoundsVolume = effectValue;
        EazySoundManager.GlobalUISoundsVolume = effectValue;
        
        _screenDropdownField.choices = new List<string> { "Full Screen", "Windowed" };

        string screenValue = PlayerPrefs.GetString("ScreenSetting", "Full Screen");

        if (_screenDropdownField.choices.Contains(screenValue))
            _screenDropdownField.value = screenValue;
        else
            Debug.LogWarning($"screen value {screenValue} is not found in choices.");
    }
    
    private void ClickOptionButton()
    {
        _settingVisualElement.style.display = DisplayStyle.Flex;
        EazySoundManager.PlayUISound(clickSound);
    }

    private void ClickExitButton()
    {
        _settingVisualElement.style.display = DisplayStyle.None;
        EazySoundManager.PlayUISound(clickSound);
    }
    
    private void ClickGameExitButton()
    {
        Time.timeScale = 1;
        EazySoundManager.PlayUISound(clickSound);
        SceneManager.LoadScene(0);
    }
    
    private void MasterSlider(ChangeEvent<float> changeEvent)
    {
        var newVolume = changeEvent.newValue / 100f; // 0~100 범위 -> 0~1로 변환
        EazySoundManager.GlobalVolume = newVolume;
        PlayerPrefs.SetFloat("Master", newVolume);
    }

    private void MusicSlider(ChangeEvent<float> changeEvent)
    {
        // 사운드 세팅
        var newVolume = changeEvent.newValue / 100f;
        EazySoundManager.GlobalMusicVolume = newVolume;
        PlayerPrefs.SetFloat("Music", newVolume);
    }

    private void EffectSlider(ChangeEvent<float> changeEvent)
    {
        // 사운드 세팅
        var newVolume = changeEvent.newValue / 100f;
        EazySoundManager.GlobalSoundsVolume = newVolume;
        EazySoundManager.GlobalUISoundsVolume = newVolume;
        PlayerPrefs.SetFloat("Effect", newVolume);
    }

    private void ScreenDropdown(ChangeEvent<string> changeEvent)
    {
        switch (changeEvent.newValue)
        {
            case "Full Screen":
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                PlayerPrefs.SetString("ScreenSetting", changeEvent.newValue);
                break;

            case "Windowed":
                Screen.fullScreenMode = FullScreenMode.Windowed;
                PlayerPrefs.SetString("ScreenSetting", changeEvent.newValue);
                break;
        }
    }
}
