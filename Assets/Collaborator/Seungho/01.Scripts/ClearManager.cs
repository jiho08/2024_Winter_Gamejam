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
        /* ���� ���� Ŭ���� ���� �ٸ��� ��� (�⺻ : ��� �� óġ)*/
        switch (SceneManager.sceneCount)
        {
            case 3:
                text.ShowText("Ż�� ���� ����");
                break;

            case 5:
                text.ShowText("��� ����ġ ����");
                break;


            default:
                text.ShowText("��� �� óġ");
                break;
        }
    }

    public IEnumerator StageClear(string message)
    {
        text.ShowText(message);
        yield return new WaitForSecondsRealtime(1f);
        
    }
}
