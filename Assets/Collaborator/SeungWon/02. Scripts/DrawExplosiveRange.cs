using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ExplosiveRange : MonoBehaviour
{
    [SerializeField] private CircleCollider2D exploreRangeCollider;

    public float explore_Range = 1f;
    public Color range_GIzmo_Color = Color.red;

    public LayerMask detectiveLayer;

    protected List<GameObject> InRangeObject = new List<GameObject>();

    public LayerMask causeExplosivelayer;

    private void OnDrawGizmosSelected()
    {
        exploreRangeCollider.radius = explore_Range;
        Gizmos.DrawWireSphere(transform.position, explore_Range);
        Gizmos.color = range_GIzmo_Color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == detectiveLayer)
        {
            InRangeObject.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == detectiveLayer)
        {
            InRangeObject.Remove(collision.gameObject);
        }
    }

    protected abstract void OnKillInRange(List<GameObject> InRangeObject);

    protected abstract void Explore();

    public abstract void Destroy();
}
