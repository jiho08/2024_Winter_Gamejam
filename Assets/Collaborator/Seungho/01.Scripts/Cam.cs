using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;

public class Cam : MonoBehaviour
{
    CinemachineImpulseSource cam;

    private void Awake()
    {
        cam = GetComponent<CinemachineImpulseSource>();
    }
    public void Shake()
    {
        cam.GenerateImpulse();
              
    }
}
