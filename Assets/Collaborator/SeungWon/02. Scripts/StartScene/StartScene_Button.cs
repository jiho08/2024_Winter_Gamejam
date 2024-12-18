using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene_Button : MonoBehaviour
{
    [SerializeField] private GameObject _settings;
    [SerializeField] private Animator settings_Animator, fade_Animator;
    [SerializeField] private GameObject StartPanel, StageSelectPanel;

    private void Awake()
    {
        StartPanel.SetActive(true);
        StageSelectPanel.SetActive(false);
    }

    public void OnSettings()
    {
        settings_Animator.SetBool("Appear", true);
    }

    public void OnExitSettings()
    {
        settings_Animator.SetBool("Appear", false);
    }

    public void OnQuit()
    {
        Application.Quit();
    }


    public void ChangeScene()
    {
        fade_Animator.gameObject.SetActive(true);
        fade_Animator.SetTrigger("Fade");

        if(StageSelectPanel.activeSelf)
        {
            StartPanel.SetActive(true);
            StageSelectPanel.SetActive(false);
        }
        else
        {
            StageSelectPanel.SetActive(true);
            StartPanel.SetActive(false);
        }
    }

    public void StageSelect(int SceneNum)
    {
        SceneManager.LoadScene(SceneNum);
    }
}
