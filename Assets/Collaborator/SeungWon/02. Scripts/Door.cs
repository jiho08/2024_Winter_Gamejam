using DG.Tweening;
using System;
using UnityEngine;
using Hellmade.Sound;

public class Door : MonoBehaviour
{
    [SerializeField] private Switch[] _connectedSwitchs;

    [SerializeField] private Transform _moveTargetPos;

    public float openingDuration;
    public AudioClip doorOpenSound;

    private void Update()
    {
        Check();
    }

    private void Check()
    {
        foreach (var obj in _connectedSwitchs)
        {
            if (!obj.open)
            {
                return;
            }
        }
        Opening();
        
    }

    private void Opening()
    {
        EazySoundManager.PlaySound(doorOpenSound);
        gameObject.transform.DOMove(_moveTargetPos.position, openingDuration);
    }
}
