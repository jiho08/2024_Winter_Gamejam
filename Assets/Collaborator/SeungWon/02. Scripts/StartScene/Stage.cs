using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public StageData stageSO;
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
                Debug.Log("�������� ���� ����");
                break;
        }    
    }

    public void EnterStage_Fade()
    {
        StartSceneManager.instance.fade_Animator.gameObject.SetActive(true);
        StartSceneManager.instance.fade_Animator.SetTrigger("Fade_ForeverDark");
        Invoke("LoadScene", 2.5f);
    }

    private void LoadScene()
    {
        if (stageSO.state != state.Lock)
            StageManager.instance.StageLoad(stageSO.stageNum);
    }
}
