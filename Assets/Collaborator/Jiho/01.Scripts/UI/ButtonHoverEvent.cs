using UnityEngine;

public class ButtonHoverEvent : MonoBehaviour
{
    [SerializeField] private Vector3 hoverScale = new (3.2f, 3.2f);
    [SerializeField] private float animationDuration = 0.2f;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnHoverEnter()
    {
        StopAllCoroutines();
        StartCoroutine(ScaleOverTime(hoverScale));
    }

    public void OnHoverExit()
    {
        StopAllCoroutines();
        StartCoroutine(ScaleOverTime(originalScale));
    }
    
    private System.Collections.IEnumerator ScaleOverTime(Vector3 targetScale)
    {
        var elapsed = 0f;
        var startScale = transform.localScale;

        while (elapsed < animationDuration)
        {
            elapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsed / animationDuration);
            yield return null;
        }

        transform.localScale = targetScale;
    }
}
