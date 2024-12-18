using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _settings;
    public Animator settings_Animator, fade_Animator;
    [SerializeField] private GameObject StartPanel, StageSelectPanel;

    public static StartSceneManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

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
        Invoke("SceneLoad", 0.4f);
    }

    private void SceneLoad()
    {
        if (StartPanel.activeSelf)
        {
            StartPanel.SetActive(false);
            StageSelectPanel.SetActive(true);
        }
        else
        {
            StageSelectPanel.SetActive(false);
            StartPanel.SetActive(true);
        }
    }
}
