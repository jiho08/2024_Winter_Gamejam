using System.Collections.Generic;
using UnityEngine;

public class Explosives_Drum : ExplosiveRange
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (causeExplosivelayer == (collision.gameObject.layer | (1 << causeExplosivelayer)))
        {
            Explore();
        }
    }

    protected override void Explore()
    {
        Debug.Log("Æã");
        OnKillInRange(InRangeObject);
    }

    protected override void OnKillInRange(List<GameObject> InRangeObject)
    {
        foreach(GameObject obj in InRangeObject)
        {
            Debug.Log("Á×À½");
        }
    }

    public override void Destroy()
    {
        Destroy(gameObject);
    }
}
