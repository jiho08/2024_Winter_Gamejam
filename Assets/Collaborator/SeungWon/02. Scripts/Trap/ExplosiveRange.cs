using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExplosiveRange : MonoBehaviour
{
    private CircleCollider2D exploreRangeCollider;

    public float explore_Range = 1f;
    public Color range_GIzmo_Color = Color.black;

    public LayerMask detectiveLayer;
    public List<GameObject> InRangeObject = new List<GameObject>();

    [SerializeField] private Explosives explosives;

    private void OnEnable()
    {
        exploreRangeCollider = GetComponent<CircleCollider2D>();

        explosives.OnExplosive += Explosive;
    }

    public void Explosive(GameObject baseTrap, GameObject causedObj)
    {
        for (int i = 0; i < InRangeObject.Count; i++)
            Destroy(InRangeObject[0]);

        if(((1 << causedObj.layer) & detectiveLayer) != 0)
            Destroy(causedObj);

        Destroy(baseTrap);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & detectiveLayer) != 0)
        {
            InRangeObject.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & detectiveLayer) != 0)
        {
            InRangeObject.Remove(collision.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        exploreRangeCollider = GetComponent<CircleCollider2D>();
        exploreRangeCollider.radius = explore_Range;
        Gizmos.DrawWireSphere(transform.position, explore_Range);
        Gizmos.color = range_GIzmo_Color;
    }

    private void OnDisable()
    {
        explosives.OnExplosive -= Explosive;
    }
}
