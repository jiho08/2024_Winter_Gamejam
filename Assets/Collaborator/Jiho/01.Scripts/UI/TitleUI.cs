using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    public void StartButton()
    {
        // 스테이지 선택 창으로
        Debug.Log("시작 버튼");
    }
    
    public void SettingButton()
    {
        // 설정 창으로
        Debug.Log("설정 버튼");
    }
    
    public void ExitButton()
    {
        Debug.Log("나가기");
        Application.Quit();
    }
}
