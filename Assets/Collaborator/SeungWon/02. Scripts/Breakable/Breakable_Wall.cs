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
            if (collision.collider.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerDeadCheck>().isDead = true;
            }
            else if(collision.collider.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Enemy>().Dead();
            }
            
            Destroy(gameObject);
            EazySoundManager.PlaySound(switchSound);
        }
    }
}
