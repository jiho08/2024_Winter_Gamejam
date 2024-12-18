using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Explosives : MonoBehaviour
{
    public LayerMask causeExplosivelayer;
    public Action<GameObject, GameObject> OnExplore;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & causeExplosivelayer) != 0)
        {
            OnExplore?.Invoke(gameObject, collision.gameObject);
        }
    }
}
