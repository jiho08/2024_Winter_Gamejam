using UnityEngine;

public class Breakable_Wall : MonoBehaviour
{
    public LayerMask canBreakObjLayer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(((1 << collision.gameObject.layer) & canBreakObjLayer) != 0)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
