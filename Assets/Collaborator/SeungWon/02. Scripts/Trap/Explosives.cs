using Hellmade.Sound;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Explosives : MonoBehaviour
{
    public LayerMask causeExplosivelayer;
    public Action<GameObject, GameObject> OnExplosive;

    public AudioClip explosiveSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & causeExplosivelayer) != 0)
        {
            OnExplosive?.Invoke(gameObject, collision.gameObject);
            EazySoundManager.PlaySound(explosiveSound);
        }
    }
}
