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
        rb.AddForce(Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized * 10, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
