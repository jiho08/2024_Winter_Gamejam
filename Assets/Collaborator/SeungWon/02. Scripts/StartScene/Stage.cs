using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public StageData stageSO;
    private Image image;
    [SerializeField] private TextMeshProUGUI _levelText;

    private void Start()
    {
        image = GetComponent<Image>();
        _levelText.text = stageSO.stageNum.ToString();
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

    public void EnterStage_Fade()
    {
        StartSceneManager.instance.fade_Animator.gameObject.SetActive(true);
        StartSceneManager.instance.fade_Animator.SetTrigger("Fade_ForeverDark");
        Invoke("LoadScene", 2.5f);
    }

    private void LoadScene()
    {
        if (stageSO.state != state.Lock)
            StageManager.instance.StageLoad(stageSO.stageSceneNum);
    }
}
