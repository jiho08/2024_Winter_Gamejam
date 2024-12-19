using System.Collections;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Back());
    }

    IEnumerator Back()
    {
        yield return new WaitForSeconds(0.5f);
        PoolManager.Return(1, gameObject);
    }
}
