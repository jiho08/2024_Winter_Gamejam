using Unity.Cinemachine;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    TrailRenderer tr;
    public ParticleSystem particle;
    public float speed;

    public bool isPenetration;
    public bool isDiffuse;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
    }

    private void OnEnable()
    {
        tr.Clear();
        rb.linearVelocity = Vector3.zero;
        
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PoolManager.Spawn(1, transform);
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            PoolManager.Return(0, gameObject);
        }
        else if (isPenetration)
        {
            rb.AddForce(transform.right * speed, ForceMode2D.Impulse);

        }
        else if (collision.gameObject.CompareTag("Player") && !isPenetration)
        {
            PoolManager.Return(0, gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy") && !isPenetration)
        {
            PoolManager.Return(0, gameObject);
        }
        

    }

    
}