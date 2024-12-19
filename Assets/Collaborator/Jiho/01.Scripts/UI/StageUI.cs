using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageUI : MonoBehaviour
{
    [SerializeField] private int _stageCount;

    [SerializeField] private Image _leftButton, _rightButton;
    [SerializeField] private TextMeshProUGUI _stageText;

    private static List<bool> _stageClearList = new();
    private int _currentStage = 1;

    private void Start()
    {
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
            SceneManager.LoadScene(_currentStage);
        else
        {
            // 안됨 사운드 해주기
        }
    }

    public void LeftArrowButton()
    {
        if (_currentStage > 1)
            --_currentStage;

        _stageText.text = _currentStage.ToString();
    }

    public void RightArrowButton()
    {
        if (_currentStage < _stageCount)
            ++_currentStage;

        _stageText.text = _currentStage.ToString();
    }
    
    public static void ClearStage(int stage)
    {
        _stageClearList[stage] = true;
    }
}