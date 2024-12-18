using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.AddForce(Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized * speed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            PoolManager.Return(0, gameObject);
        }
    }
}
