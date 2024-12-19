using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearManager : MonoBehaviour
{
    private TextAction text;


    public void Start()
    {
        
        StageStart();
    }

    public void StageStart()
    {
        /* 씬에 따라 클리어 조건 다르게 출력 (기본 : 모든 적 처치)*/
        switch (SceneManager.sceneCount)
        {
            case 3:
                text.ShowText("탈출 지점 도달");
                break;

            case 5:
                text.ShowText("모든 스위치 가동");
                break;


            default:
                text.ShowText("모든 적 처치");
                break;
        }
    }

    public IEnumerator StageClear(string message)
    {
        text.ShowText(message);
        yield return new WaitForSecondsRealtime(1f);
        
    }
}
