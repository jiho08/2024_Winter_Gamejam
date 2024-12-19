using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class TextAction : MonoBehaviour
{
    public Volume volume;
    

    private void Start()
    {
        /* 씬에 따라 클리어 조건 다르게 출력 (기본 : 모든 적 처치)*/
        switch (SceneManager.sceneCount)
        {
            case 3: 
                ShowText("탈출 지점 도달");
                break;

            case 5:
                ShowText("모든 스위치 가동");
                break;


            default:
                ShowText("모든 적 처치");
                break;
        }
        
    }

    public void ShowText(string content)
    {
        transform.parent.DOScale(new Vector3(1, 1, 1), 0.1f).SetEase(Ease.OutExpo);
        if (volume.profile.TryGet<DepthOfField>(out var distortion))
        {

            StartCoroutine(TextShowEffect(distortion, 5f));
        }
    }

    IEnumerator TextShowEffect(DepthOfField depthOfField, float effectSpeed)
    {
        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime * effectSpeed;
            depthOfField.focalLength.value = Mathf.Lerp(300f, 1f, time);
            depthOfField.aperture.value = Mathf.Lerp(1f, 32f, time);
            
            yield return null;

        }
        yield return new WaitForSecondsRealtime(0.5f);
        time = 0;
        var a = GetComponent<TextMeshPro>();
        while (time < 1)
        {
            time += Time.deltaTime;
            a.color = Color.Lerp(a.color, new Color(255, 255, 255, 0), time);

            yield return null;

        }
        transform.parent.gameObject.SetActive(false);
    }
}
