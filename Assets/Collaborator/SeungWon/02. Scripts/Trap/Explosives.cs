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
        if (collision.gameObject.layer == (collision.gameObject.layer | (1 << causeExplosivelayer)))
        {
            OnExplore?.Invoke(gameObject, collision.gameObject);
        }
    }
}
