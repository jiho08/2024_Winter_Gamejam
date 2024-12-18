using Unity.Cinemachine;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    TrailRenderer tr;
    public float speed;
    public Transform owner;
    public bool isPenetration;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        owner = transform;
    }

    private void OnEnable()
    {
        tr.Clear();
        rb.linearVelocity = Vector3.zero;
        rb.AddForce(owner.transform.right * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PoolManager.Return(0, gameObject);
        //if (collision.gameObject.CompareTag("Wall"))
        //{
        //    PoolManager.Return(0, gameObject);
        //}
        //else if (collision.gameObject.CompareTag("Player") && !isPenetration)
        //{
        //    PoolManager.Return(0, gameObject);
        //}

    }
}