using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TextAction : MonoBehaviour
{
    public Volume volume;

    private void Start()
    {
        
        if (volume.profile.TryGet<LensDistortion>(out var distortion))
        {
            

            StartCoroutine(TextShowEffect(distortion, 10f));
        }
    }

    IEnumerator TextShowEffect(LensDistortion lensDistortion, float effectSpeed)
    {
        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime * effectSpeed;
            lensDistortion.intensity.value = Mathf.Lerp(0.5f, 0.38f, time);
            
            yield return null;

        }
        yield return new WaitForSecondsRealtime(1);
        gameObject.SetActive(false);
    }
}
