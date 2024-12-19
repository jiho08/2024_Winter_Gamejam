using UnityEngine;
using Hellmade.Sound;

public class Breakable_Wall : MonoBehaviour
{
    public LayerMask canBreakObjLayer;
    public AudioClip switchSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(((1 << collision.gameObject.layer) & canBreakObjLayer) != 0)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            EazySoundManager.PlaySound(switchSound);
        }
    }
}
