using UnityEngine;
using UnityEngine.UI;

public class StartScene_Button : MonoBehaviour
{
    [SerializeField] private GameObject _settings;
    [SerializeField] private Animator settings_Animator, fade_Animator;
    [SerializeField] private Image _fade;

    public void OnPlay()
    {
        fade_Animator.SetTrigger("Fade");
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
}
