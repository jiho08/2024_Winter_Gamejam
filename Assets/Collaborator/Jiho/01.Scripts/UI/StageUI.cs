using System;
using System.Collections.Generic;
using Hellmade.Sound;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageUI : MonoBehaviour
{
    [SerializeField] private int _stageCount;

    [SerializeField] private Image _leftButton, _rightButton;
    [SerializeField] private TextMeshProUGUI _stageText;

    [SerializeField] private AudioClip clickSound, noSound;

    private static List<bool> _stageClearList = new();
    private int _currentStage = 1;

    private void Start()
    {
        for (int i = 0; i < _stageCount; i++)
            _stageClearList.Add(false);

        _currentStage = 1;
        _stageClearList[0] = true;
    }

    private void Update()
    {
        _rightButton.enabled = _currentStage != _stageCount;
        _leftButton.enabled = _currentStage != 1;
    }

    public void ShotButton()
    {
        if (_stageClearList[_currentStage - 1])
        {
            EazySoundManager.PlayUISound(clickSound);
            SceneManager.LoadScene(_currentStage);
        }
        else
        {
            EazySoundManager.PlayUISound(noSound);
            // 안됨 사운드 해주기
        }
    }

    public void LeftArrowButton()
    {
        if (_currentStage > 1)
        {
            --_currentStage;
            EazySoundManager.PlayUISound(clickSound);
            _stageText.text = _currentStage.ToString();
        }
    }

    public void RightArrowButton()
    {
        if (_currentStage < _stageCount)
        {
            ++_currentStage;
            EazySoundManager.PlayUISound(clickSound);
            _stageText.text = _currentStage.ToString();
        }
    }

    public static void ClearStage(int stage)
    {
        _stageClearList[stage] = true;
    }
}