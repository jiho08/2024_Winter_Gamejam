using Unity.Cinemachine;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Transform owner;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        owner = transform;   
    }

    private void OnEnable()
    {
        rb.linearVelocity = Vector3.zero;
        rb.AddForce(owner.transform.right * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            PoolManager.Return(0, gameObject);
            
        }
    }
}
