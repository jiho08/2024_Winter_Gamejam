using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    PlayerMove player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<PlayerMove>();
    }

    private void OnEnable()
    {
        rb.linearVelocity = Vector3.zero;
        rb.AddForce(player.transform.right * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            PoolManager.Return(0, gameObject);
            
        }
    }
}
