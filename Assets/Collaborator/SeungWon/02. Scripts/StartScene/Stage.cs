using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public StageSO stageSO;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        switch(stageSO.state)
        {
            case state.Lock:
                image.sprite = stageSO.lockStageImage;
                break;
            case state.Unlock:
                image.sprite = stageSO.unlockStageImage;
                break;
            case state.Complete:
                image.sprite = stageSO.completeStageImage;
                break;
            default:
                Debug.Log("스테이지 상태 없음");
                break;
        }    
    }

    public void EnterStage()
    {
        StageManager.instance.StageLoad(stageSO.stageNum);
    }
}
