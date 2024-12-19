using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    [SerializeField] private List<CinemachineCamera> cameraList = new();

    public void StartButton()
    {
        // 스테이지 선택 창으로
        Debug.Log("시작 버튼");

        (cameraList[0].Priority, cameraList[2].Priority) = (cameraList[2].Priority, cameraList[0].Priority);
    }

    public void SettingButton()
    {
        // 설정 창으로
        Debug.Log("설정 버튼");
        (cameraList[0].Priority, cameraList[1].Priority) = (cameraList[1].Priority, cameraList[0].Priority);
    }

    public void ExitButton()
    {
        Debug.Log("나가기");
        Application.Quit();
    }
    
    public void BackButton()
    {
        Debug.Log("두ㅣ로");
        (cameraList[0].Priority, cameraList[1].Priority) = (cameraList[1].Priority, cameraList[0].Priority);
    }
}